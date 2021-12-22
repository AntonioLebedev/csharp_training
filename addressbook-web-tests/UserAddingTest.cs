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
            app1.Navigator1.GoToHomePage();
            app1.Auth1.Login(new AccountData("admin", "secret"));
            app1.Contacts.ClickAddNew();
            ContactData contact = new ContactData("Alexander", "Viktorovich", "Biryukov");
            app1.Contacts.FillContactData(contact);
            app1.Contacts.ContactCreationConfirm();
            app1.Navigator1.BackToHomePage();
            app1.Auth1.Logout();
        }
    }
}