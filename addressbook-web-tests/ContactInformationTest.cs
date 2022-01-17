using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
           ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            // Verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address1, fromForm.Address1);
            Assert.AreEqual(fromTable.Allphones, fromForm.Allphones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

    }
}
