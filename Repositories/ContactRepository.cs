using PacktContactsCore.Data;
using PacktContactsCore.Interfaces;
using PacktContactsCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PacktContactsCore.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;
        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }
        public Contact AddContact(Contact _object)
        {
            _context.Add(_object);
            return _object;
        }

        public void DeleteContact(Contact _object)
        {
            _context.Remove(_object);
        }

        public Contact GetContact(int productId)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == productId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        public bool ContactExists(int productId)
        {
            return _context.Contacts.Any(x => x.Id == productId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateContact(Contact _object)
        {
            _context.Update(_object);
        }
    }
}
