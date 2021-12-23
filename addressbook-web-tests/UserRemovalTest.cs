using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemovalTests : TestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
