using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactModel.POCOClasses;
using ContactModel.Repository;


    public static class RepositoryExtensions
    {
        public static void UpdateContact(this Contact oldContact, Contact newContact)
        {
            //var oldContact = contacts.SingleOrDefault(i => i.Id == newContact.Id);
            oldContact.FirstName = newContact.FirstName;
            oldContact.LastName = newContact.LastName;
            oldContact.Email = newContact.Email;
            oldContact.PhoneNumber = newContact.PhoneNumber;
            oldContact.Status = newContact.Status;
        }

    }

