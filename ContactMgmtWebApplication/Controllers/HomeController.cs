using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Text;
using ContactModel.POCOClasses;
using ContactMgmtWebApplication.ErrorHandler;
using ContactMgmtWebApplication.Filters;

namespace ContactMgmtWebApplication.Controllers
{
    [CustomErrorHandler]
    [Authentication]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Contact> contacts = new List<Contact>();

            using (HttpClient client = new HttpClient())
            {
                //var credentials = Encoding.ASCII.GetBytes("chintanjspmit@rediffmail.com:kokila@2013");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response = client.GetAsync("http://localhost:3045/api/contact").Result;
                HttpResponseMessage response = client.GetAsync("http://localhost/contactmanagement/api/contact").Result;
                if (response.IsSuccessStatusCode)
                {
                    contacts = response.Content.ReadAsAsync<IEnumerable<Contact>>().Result.ToList();
                }
            }

            return View(contacts);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            Contact contactModel = new Contact();
            return PartialView("AddContact",contactModel);
        }

        private Contact GetContact(int id)
        {
            Contact contact = new Contact();
            using (HttpClient client = new HttpClient())
            {
                var credentials = Encoding.ASCII.GetBytes("chintanjspmit@rediffmail.com:kokila@2013");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("http://localhost/contactmanagement/api/contact/" + id).Result;
                //HttpResponseMessage response = client.GetAsync("http://localhost:3045/api/contact/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    contact = response.Content.ReadAsAsync<Contact>().Result;
                }
            }
            return contact;
        }


        [HttpGet]
        public ActionResult EditContact(int id)
        {
            Contact contact = GetContact(id);
            return PartialView("EditContact", contact);
        }

        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            Contact contact = GetContact(id);
            return PartialView("DeleteContact", contact);
        }

        //[HttpPost]
        //public ActionResult AddContact(Contact contactModel)
        //{
        //    return RedirectToAction("Index");
        //}
        
    }
}