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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactsPage();
            SelectContact(1);
            RemoveContact();
        }
    }
}
