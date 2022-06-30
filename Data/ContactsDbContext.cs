using Microsoft.EntityFrameworkCore;
using PacktContactsCore.Models;

namespace PacktContactsCore.Data
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> contextOptions) : base(contextOptions) { }
        public ContactsDbContext() { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
