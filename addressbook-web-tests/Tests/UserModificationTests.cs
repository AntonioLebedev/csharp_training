using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            ContactData newData = new ContactData("Feofan", null, null);
            app.Contacts.Modify(1, newData);
            app.Auth.Logout();
        }


    }
}
