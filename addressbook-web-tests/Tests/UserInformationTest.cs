using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserInformationTests : AuthTestBase
    {
        [Test]
        public void UserInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetInfoFromEditForm();

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address.Trim());
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }

        [Test]
        public void UserDetailsTest()
        {
            string fromDetails = app.Contacts.GetInfoFromDetailsForm();
            ContactData fromForm = app.Contacts.GetInfoFromEditForm();

            //verification
            Assert.AreEqual(fromDetails, fromForm.AllInformation);
        }
    }
}