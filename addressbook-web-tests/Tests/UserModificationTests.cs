using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {
        [Test]
        public void UserModificationTest()
        {
            ContactData newData = (new ContactData("Vasiliy", "Barsukov"));
            newData.Middlename = "Grigorievich";

            app.Contacts.IsContactPresent();

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeModified = oldContacts[0];
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactQuantity());


            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, toBeModified.Lastname);
                    Assert.AreEqual(newData.Firstname, toBeModified.Firstname);
                }
            }

        }
    }
}