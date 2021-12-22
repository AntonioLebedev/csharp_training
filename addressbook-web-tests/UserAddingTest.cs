using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserAdding : TestBase1
    {
        [Test]
        public void UserAddingTest()
        {
            ContactData contact = new ContactData("Alexander", "Viktorovich", "Biryukov");
            app1.Contacts.Create(contact);
            app1.Auth1.Logout();
        }

        [Test]
        public void EmptyUserAddingTest()
        {
            ContactData contact = new ContactData("", "", "");
            app1.Auth1.Logout();
            app1.Contacts.Create(contact);
        }
    }
}