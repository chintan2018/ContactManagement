using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactModel.Repository;
using ContactModel.POCOClasses;
using ContactManagement.ExceptionHandler;

namespace ContactManagement.Controllers
{
 
    [CustomErrorHandler]
    public class ContactController : ApiController
    {
        IRepository<Contact> contactRepository;

        public ContactController(IRepository<Contact> repository)
        {
            contactRepository = repository;
        }

        //api/contact
        //GET
        public IEnumerable<Contact> Get()
        {
            var obj = contactRepository.GetAll();
            var list = obj.ToList();
            return obj;
        }

        //api/contact/1
        //GET
        public Contact Get(long id)
        {
            Contact contact = contactRepository.Get(id);
            return contact;
        }

        //api/contact
        //POST
        [ValidateModel]
        [HttpPost]
        public void Post(Contact contact)
        {
                contact.AddedBy = User.Identity.Name;
                contact.UpdatedBy = null;
                contact.AddedTimestamp = DateTime.Now;
                contact.UpdatedTimestamp = DateTime.Now;
                contactRepository.Insert(contact);
        }

        //api/contact/1
        //PUT
        [ValidateModel]
        [HttpPut]
        public void Put(long id, Contact contact)
        {
            Contact contactObj = contactRepository.Get(id);
            if (contactObj != null)
            {
                contactObj.FirstName = contact.FirstName;
                contactObj.LastName = contact.LastName;
                contactObj.PhoneNumber = contact.PhoneNumber;
                contactObj.Email = contact.Email;
                contactObj.Status = contact.Status;
                contactObj.UpdatedTimestamp = DateTime.Now;
                contactObj.UpdatedBy = contactObj.UpdatedBy;

                contactRepository.Update(contactObj);
            }
        }

        //api/contact/1
        //DELETE
        [HttpDelete]
        public void Delete(long id, Contact contact)
        {
            Contact contactObj = contactRepository.Get(id);
            if (contactObj != null)
            {
                contactRepository.Delete(contactObj);
            }
        }
    }
}
