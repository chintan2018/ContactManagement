using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactModel.POCOClasses;
using ContactModel.Repository;

namespace ContactManagement.Service
{
    public class ContactService : IContactService
    {
        IRepository<Contact> contactRepository;

        public ContactService(IRepository<Contact> repository)
        {
            contactRepository = repository;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return contactRepository.GetAll();
        }
    }
}