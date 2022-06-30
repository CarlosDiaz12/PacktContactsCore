using PacktContactsCore.Models;
using System.Collections.Generic;

namespace PacktContactsCore.Interfaces
{
    public interface IContactRepository
    {
        Contact AddContact(Contact _object);
        void DeleteContact(Contact _object);
        void UpdateContact(Contact _object);
        Contact GetContact(int productId);
        IEnumerable<Contact> GetContacts();
        bool ContactExists(int productId);
        bool Save();
    }
}
