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
        public HelperBase1(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}