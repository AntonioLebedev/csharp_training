﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemovalTests : AuthTestBase
    {


        [Test]
        public void UserRemovalTest()
        {
            app.Contacts.IsContactPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactQuantity());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}