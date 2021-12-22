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
    public class HelperBase1
    {
        protected IWebDriver driver;
        protected ApplicationManager1 manager1;
        public HelperBase1(ApplicationManager1 manager1)
        {
            this.manager1 = manager1;
            driver = manager1.Driver;
        }
    }
}