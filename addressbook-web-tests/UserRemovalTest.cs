using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemovalTests : TestBase1
    {
        [Test]
        public void UserRemovalTest()
        {
            app1.Navigator1.GoToHomePage();
            app1.Auth1.Login(new AccountData("admin", "secret"));
            app1.Navigator1.GoToContactsPage();
            app1.Contacts.SelectContact(1);
            app1.Contacts.RemoveContact();
        }
    }
}
