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
            ContactData newData = new ContactData("Feofan", null, null);
            app.Contacts.Modify(0, newData);
            app.Auth.Logout();
        }


    }
}
