using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
    public class AddingContactToGroupTests : ContactTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactData> contactlist = ContactData.GetAllContacts();
            ContactData newcontact = new ContactData("Ivan", "Kruzenshtern");
            newcontact.Middlename = "Fedorovich";
            GroupData newgroup = new GroupData("new group");

            if (grouplist.Count == 0)
            {
                app.Groups.Create(newgroup);

                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }
            else
            {
                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.SequenceEqual(ContactData.GetAllContacts()))
            {
                app.Contacts.Create(newcontact);
            }

            ContactData contact = ContactData.GetAllContacts().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
