using System;
using System.ComponentModel.DataAnnotations;

namespace PacktContactsCore.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
