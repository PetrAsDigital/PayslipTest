using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipLib;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTestPayCalc
    {
        [TestMethod]
        public void TestMethod_Category_1()
        {
            IPerson person = new Person("David", "Rudd", 1200, 9, DateTime.Now, DateTime.Now);
            var allPersons = new List<IPerson>() { person };

            var payCalc = new PayCalc_2017();
            payCalc.ProcessAllPersons(allPersons);

            var person_result = allPersons.FirstOrDefault(a => a.FirstName == person.FirstName && a.LastName == person.LastName);

            Assert.AreEqual(person_result.Salary, 1200);
            Assert.AreEqual(person_result.GrossIncome, 100);
            Assert.AreEqual(person_result.IncomeTax, 0);
            Assert.AreEqual(person_result.NetIncome, 100);
            Assert.AreEqual(person_result.Super, 9);
        }

        [TestMethod]
        public void TestMethod_Category_2()
        {
            IPerson person = new Person("David", "Rudd", 24000, 10, DateTime.Now, DateTime.Now);
            var allPersons = new List<IPerson>() { person };

            var payCalc = new PayCalc_2017();
            payCalc.ProcessAllPersons(allPersons);

            var person_result = allPersons.FirstOrDefault(a => a.FirstName == person.FirstName && a.LastName == person.LastName);

            Assert.AreEqual(person_result.Salary, 24000);
            Assert.AreEqual(person_result.GrossIncome, 2000);
            Assert.AreEqual(person_result.IncomeTax, 92);
            Assert.AreEqual(person_result.NetIncome, 1908);
            Assert.AreEqual(person_result.Super, 200);
        }

        [TestMethod]
        public void TestMethod_Category_3()
        {
            IPerson person = new Person("David", "Rudd", 60050, 9, DateTime.Now, DateTime.Now);
            var allPersons = new List<IPerson>() { person };

            var payCalc = new PayCalc_2017();
            payCalc.ProcessAllPersons(allPersons);

            var person_result = allPersons.FirstOrDefault(a => a.FirstName == person.FirstName && a.LastName == person.LastName);

            Assert.AreEqual(person_result.Salary, 60050);
            Assert.AreEqual(person_result.GrossIncome, 5004);
            Assert.AreEqual(person_result.IncomeTax, 922);
            Assert.AreEqual(person_result.NetIncome, 4082);
            Assert.AreEqual(person_result.Super, 450);
        }

        [TestMethod]
        public void TestMethod_Category_4()
        {
            IPerson person = new Person("Ryan", "Chen", 120000, 10, DateTime.Now, DateTime.Now);
            var allPersons = new List<IPerson>() { person };

            var payCalc = new PayCalc_2017();
            payCalc.ProcessAllPersons(allPersons);

            var person_result = allPersons.FirstOrDefault(a => a.FirstName == person.FirstName && a.LastName == person.LastName);

            Assert.AreEqual(person_result.Salary, 120000);
            Assert.AreEqual(person_result.GrossIncome, 10000);
            Assert.AreEqual(person_result.IncomeTax, 2696);
            Assert.AreEqual(person_result.NetIncome, 7304);
            Assert.AreEqual(person_result.Super, 1000);
        }

        [TestMethod]
        public void TestMethod_Category_5()
        {
            IPerson person = new Person("Ryan", "Chen", 1000000, 10, DateTime.Now, DateTime.Now);
            var allPersons = new List<IPerson>() { person };

            var payCalc = new PayCalc_2017();
            payCalc.ProcessAllPersons(allPersons);

            var person_result = allPersons.FirstOrDefault(a => a.FirstName == person.FirstName && a.LastName == person.LastName);

            Assert.AreEqual(person_result.Salary, 1000000);
            Assert.AreEqual(person_result.GrossIncome, 83333);
            Assert.AreEqual(person_result.IncomeTax, 35296);
            Assert.AreEqual(person_result.NetIncome, 48037);
            Assert.AreEqual(person_result.Super, 8333);
        }
    }
}
