using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Serialization;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(50))
                {
                    Middlename = GenerateRandomString(50)

                });
            }
            return contacts;
        }

        //public static IEnumerable<ContactData> ContactDataFromCSVFile()
        //{
            //List<ContactData> contacts = new List<ContactData>();
            //string[] lines = File.ReadAllLines(@"contacts.csv");
            //foreach (string l in lines)
            //{
                //string[] parts = l.Split(',');
                //contacts.Add(new ContactData(parts[0], parts[2])
                //{
                    //Middlename = parts[1],
                //});
            //}
            //return contacts;
        //}

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        //public static IEnumerable<ContactData> ContactDataFromExcelFile()
        //{
            //List<ContactData> contacts = new List<ContactData>();
            //Excel.Application app = new Excel.Application();
            //Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            //Excel.Worksheet sheet = wb.ActiveSheet;
            //Excel.Range range = sheet.UsedRange;

            //for (int i = 1; i <= range.Rows.Count; i++)
            //{
                //contacts.Add(new ContactData()
                //{
                    //Firstname = range.Cells[i, 1].Value,
                    //Middlename = range.Cells[i, 2].Value,
                    //Lastname = range.Cells[i, 3].Value,
                //});
            //}
            //wb.Close();
            //app.Visible = false;
            //app.Quit();

            //return contacts;
        //}

        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void UserCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAllContacts();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactQuantity());

            List<ContactData> newContacts = ContactData.GetAllContacts();
            newContacts.Sort();
            contact.Id = newContacts[newContacts.Count - 1].Id;
            oldContacts.Add(contact);
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactInGroups()
        {
            foreach (GroupData group in ContactData.GetAllContacts()[0].GetGroups())
            {
                System.Console.Out.WriteLine(group);
            }

        }

        [Test]

        public void TestContactDBConnectivity()
        {
            DateTime start = DateTime.Now;

            List<ContactData> fromUI = app.Contacts.GetContactList();

            DateTime end = DateTime.Now;

            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            
            List<ContactData> fromDb = ContactData.GetAllContacts();

            end = DateTime.Now;

            System.Console.Out.WriteLine(end.Subtract(start));
        }

    }
}