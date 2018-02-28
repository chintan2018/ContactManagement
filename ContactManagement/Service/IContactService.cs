using System.Collections.Generic;
using ContactModel.POCOClasses;

namespace ContactManagement.Service
{
    interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
    }
}
