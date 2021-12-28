using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Contacts.Create(contact);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyUserAddingTest()
        {
            ContactData contact = new ContactData("", "", "");
            app.Auth.Logout();
            app.Contacts.Create(contact);
        }
    }
}