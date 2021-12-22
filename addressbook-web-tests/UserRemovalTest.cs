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
            app1.Contacts.Remove(1);
        }
    }
}
