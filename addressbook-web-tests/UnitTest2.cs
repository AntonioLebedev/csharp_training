using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = null;
            int attempt = 0;

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt = attempt + 1;
            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
