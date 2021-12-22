using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase1
    {

        protected ApplicationManager1 app1;

        [SetUp]
        public void SetupTest()
        {
            app1 = new ApplicationManager1();
            app1.Navigator1.GoToHomePage();
            app1.Auth1.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app1.Stop1();
        }
    }
}
