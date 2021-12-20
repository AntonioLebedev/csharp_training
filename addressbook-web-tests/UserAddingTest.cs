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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            ClickAddNew();
            ContactData contact = new ContactData("Alexander", "Viktorovich", "Biryukov");
            FillContactData(contact);
            ContactCreationConfirm();
            BackToHomePage();
            Logout();
        }
    }
}