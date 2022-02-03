using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemovalTests : AuthTestBase
    {


        [Test]
        public void UserRemovalTest()
        {
            app.Contacts.IsContactPresent();

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            
            ContactData toBeRemoved = oldContacts[1];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactQuantity());


            List<ContactData> newContacts = ContactData.GetAllContacts();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}