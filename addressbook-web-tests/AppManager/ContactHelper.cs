using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            InitNewContactCreation();
            ClickAddNew();
            FillContactData(contact);
            ContactCreationConfirm();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement element in elements)
            {
                IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                //второй вариант реализации
                //IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                //IWebElement lastname = cells[1];
                //IWebElement firstname = cells[2];
                contacts.Add(new ContactData(firstname.Text, null, lastname.Text));

            }
            return contacts;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(v);
            InitContactModification(v);
            FillContactData(newData);
            ContactModificationConfirm();
            return this;
        }


        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public ContactHelper CreateContactIfNotPresent()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
            {
                ContactData contact = (new ContactData("Ivan", "Ivanovich", "Fedorov"));
                Create(contact);
            }
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            Type(By.Name("nickname"), contact.Nickname);
            driver.FindElement(By.Name("title")).Click();
            Type(By.Name("title"), contact.Title);
            driver.FindElement(By.Name("company")).Click();
            Type(By.Name("company"), contact.Company);
            driver.FindElement(By.Name("address")).Click();
            Type(By.Name("address"), contact.Address1);
            driver.FindElement(By.Name("home")).Click();
            Type(By.Name("home"), contact.Homephone);
            driver.FindElement(By.Name("mobile")).Click();
            Type(By.Name("mobile"), contact.Mobilephone);
            driver.FindElement(By.Name("work")).Click();
            Type(By.Name("work"), contact.Workphone);
            driver.FindElement(By.Name("fax")).Click();
            Type(By.Name("fax"), contact.Fax);
            driver.FindElement(By.Name("email")).Click();
            Type(By.Name("email"), contact.Email);
            driver.FindElement(By.Name("email2")).Click();
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            Type(By.Name("homepage"), contact.Homepage);
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            //driver.FindElement(By.Name("ayear")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            driver.FindElement(By.Name("address2")).Click();
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            Type(By.Name("notes"), contact.Note);
            return this;
        }

        public ContactHelper ContactCreationConfirm()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }


        public ContactHelper ContactModificationConfirm()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper ClickAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}
