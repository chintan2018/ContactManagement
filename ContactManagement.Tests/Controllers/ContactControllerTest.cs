using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManagement;
using ContactManagement.Controllers;
using ContactManagement.Models;
using Moq;
using ContactModel.POCOClasses;
using ContactModel.Repository;
using System.Collections.Generic;
using System.Linq;
using ContactManagement.Tests;

namespace ContactManagement.Tests.Controllers
{

    [TestClass]
    public class ContactControllerTest
    {
        public static  Mock<IRepository<Contact>> _mock;
        public static  List<Contact> contacts;
        public static  ContactController _controller;
               

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _mock = new Mock<IRepository<Contact>>();
            contacts = new List<Contact>();
            _controller = new ContactController(_mock.Object);

            //Insert
            _mock.Setup(i => i.Insert(It.IsAny<Contact>()))
                .Callback((Contact item) => contacts.Add(item));

            //Update
            _mock.Setup(i => i.Update(It.IsAny<Contact>()))
                .Callback((Contact item) => contacts.SingleOrDefault<Contact>(i => i.Id == item.Id).UpdateContact(item));
            
            //Delete
            _mock.Setup(i => i.Delete(It.IsAny<Contact>()))
                .Callback((Contact item) => contacts.Remove(item));
        }
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _mock = null;
            contacts = null;
            _controller = null;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }

        [TestMethod]
        public void GetById_InvalidID()
        {
            // Arrange
            // Act
            Contact result = _controller.Get(0);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddContact()
        {
            // Arrange
            // Act
            Contact obj = new Contact()
            {
                Id = 1,
                FirstName = "TestUser",
                LastName = "TestLast",
                Email = "abc@rediffmail.com",
                PhoneNumber = "1234567890",
                Status = "Active"
            };
            _controller.Post(obj);
            //Assert
            Assert.AreEqual(contacts.Any(item => item.Id == 1), true);
        }

        [TestMethod]
        public void GetAllContacts()
        {
            // Arrange
            // Act
            IEnumerable<Contact> result = _controller.Get();
            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void UpdateContact()
        {
            Contact obj1 = new Contact()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "TestLast",
                Email = "abc@rediffmail.com",
                PhoneNumber = "1234567890",
                Status = "Active"
            };

            Contact obj2 = new Contact()
            {
                Id = 1,
                FirstName = "Chintan",
                LastName = "Purohit",
                Email = "abc@rediffmail.com",
                PhoneNumber = "1234567890",
                Status = "Active"
            };
            _controller.Post(obj1);
            _controller.Put(1, obj2);
            
        }

        [TestMethod]
        public void DeleteContact()
        {
            Contact obj = new Contact()
            {
                Id = 1,
                FirstName = "TestUser",
                LastName = "TestLast",
                Email = "abc@rediffmail.com",
                PhoneNumber = "1234567890",
                Status = "Active"
            };
            //_controller.Post(obj);
            _controller.Delete(1, obj);
            
        }

    }
}
