using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PacktContactsCore.Interfaces;
using PacktContactsCore.Models;
using System.Linq;

namespace PacktContactsCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_contactRepository.GetContacts());

        [HttpGet("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            if(!_contactRepository.ContactExists(Id)) return NotFound(new { error = "Resource not found."});
            var result = _contactRepository.GetContact(Id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            var newContact = _contactRepository.AddContact(contact);
            if (!_contactRepository.Save()) return StatusCode(500, new { error = "Error ocurred while creating contact." });

            return CreatedAtAction(nameof(GetById), new { Id = newContact.Id }, newContact);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Contact contact)
        {
            if (!_contactRepository.ContactExists(contact.Id)) return NotFound(new { message = "Resource not found." });
            _contactRepository.UpdateContact(contact);

            if (!_contactRepository.Save()) return StatusCode(500, new { error = "Error ocurred while updating contact." });

            return Ok();    
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            var contact = _contactRepository.GetContact(Id);
            if (contact == null) return NotFound(new { message = "Resource not found." });

            _contactRepository.DeleteContact(contact);
            if (!_contactRepository.Save()) return StatusCode(500, new { error = "Error ocurred while updating contact." });

            return Ok();
        }
    }
}
