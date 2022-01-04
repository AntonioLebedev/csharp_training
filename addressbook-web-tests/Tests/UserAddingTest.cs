using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserAdding : AuthTestBase
    {
        [Test]
        public void UserAddingTest()
        {
            ContactData contact = new ContactData("Alexander", "Viktorovich", "Biryukov");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            app.Auth.Logout();
        }

        [Test]
        public void EmptyUserAddingTest()
        {
            ContactData contact = new ContactData("", "", "");
            app.Auth.Logout();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}