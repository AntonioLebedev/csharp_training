using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager1
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected bool acceptNextAlert = true;
        protected LoginHelper1 loginHelper1;
        protected NavigationHelper1 navigator1;
        protected ContactHelper contactHelper;

        public ApplicationManager1()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";

            loginHelper1 = new LoginHelper1(this);
            navigator1 = new NavigationHelper1(this, baseURL);
            contactHelper = new ContactHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public void Stop1()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper1 Auth1
        {
            get
            {
                return loginHelper1;
            }
        }

        public NavigationHelper1 Navigator1
        {
            get
            {
                return navigator1;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }

}

