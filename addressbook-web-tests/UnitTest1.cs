using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 900;
            bool vipClient = true;

            if (total > 1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("скидка 10%, общая сумма " + total);
            }
            else
            {
                System.Console.Out.Write("скидки нет, общая сумма " + total);
            }
        }
    }
}
