using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using WebAddressbookTests;
using System.Xml;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Serialization;

namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string objectType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Middlename = TestBase.GenerateRandomString(10)
                });
            }

            StreamWriter writer = new StreamWriter(filename);



            if (objectType == "groups")
            {
                if (format == "xml")
                {
                    writeGroupsToXMLFile(groups, writer);
                }

                else
                {
                    if (format == "json")
                    {
                        writeGroupsToJSONFile(groups, writer);
                    }

                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    
                    writer.Close();
                }
            }
            
            else if (objectType == "contacts")
            {
                if (format == "xml")
                {
                    writeContactsToXMLFile(contacts, writer);
                }

                else
                {
                    if (format == "json")
                    {
                        writeContactsToJSONFile(contacts, writer);
                    }

                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }

                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of object: " + objectType);
            }

        }


        //static void writeContactsToCSVFile(List<ContactData> contacts, StreamWriter writer)
        //{
            //foreach (ContactData contact in contacts)
            //{
                //writer.WriteLine(String.Format("${0},${1},${2}",
                    //contact.Firstname, contact.Middlename, contact.Lastname));
            //}
        //}

        //static void writeGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        //{
            //foreach (GroupData group in groups)
            //{
                //writer.WriteLine(String.Format("${0},${1},${2}",
                    //group.Name, group.Header, group.Footer));
            //}
        //}

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        //static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        //{
            //Excel.Application app = new Excel.Application();
            //app.Visible = true;
            //Excel.Workbook wb = app.Workbooks.Add();
            //Excel.Worksheet sheet = wb.ActiveSheet;

            //int row = 1;

            //foreach (GroupData group in groups)
            //{
                //sheet.Cells[row, 1] = group.Name;
                //sheet.Cells[row, 2] = group.Header;
                //sheet.Cells[row, 3] = group.Footer;
                //row++;
            //}


            //string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            //File.Delete(fullPath);
            //wb.SaveAs(fullPath);

            //wb.Close();
            //app.Visible = false;
            //app.Quit();
        //}

    }

}
