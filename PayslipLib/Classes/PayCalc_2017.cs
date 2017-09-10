using PayslipLib.Classes;
using PayslipLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayslipLib
{
    public class PayCalc_2017: IPayCalc
    {
        ITaxTable taxTable = new TaxTable2017();

        public List<IPerson> ProcessAllPersons(List<IPerson> allPersons)
        {
            if (allPersons == null || allPersons.Count < 1)
                throw new Exception("No persons to process...");

            foreach (var onePerson in allPersons)
            {
                onePerson
                    .SetPayPeriod(GetPayPeriod(onePerson))
                    .SetGrossIncome(GetGrossIncome(onePerson))
                    .SetIncomeTax(GetIncomeTax(onePerson))
                    .SetNetIncome(GetNetIncome(onePerson))
                    .SetSuper(GetSuper(onePerson));
            }

            return allPersons;
        }

        public ITaxTable GetTaxTable()
        {
            return new TaxTable2017();
        }

        private int GetPayPeriod(IPerson person)
        {
            return person.PaymentStartDate.Month;
        }

        private double GetGrossIncome(IPerson person)
        {
            var result = Math.Floor((double)person.Salary / 12);
            return result;
        }

        private double GetIncomeTax(IPerson person)
        {
            CheckTaxTable();

            double result = 0;

            foreach (var item in taxTable.TaxTableItems.OrderByDescending(a => a.OrderNum))
            {
                if (person.Salary > item.MinValue)
                {
                    result = Math.Ceiling((item.BaseTax + ((person.Salary - item.MinValue) * item.Tax / 100)) / 12);
                    break;
                }
            }

            return result;
        }

        private double GetNetIncome(IPerson person)
        {
            return person.GrossIncome - person.IncomeTax;
        }

        private double GetSuper(IPerson person)
        {
            CheckTaxTable();
            return Math.Floor(person.GrossIncome * taxTable.Super / 100);
        }

        private void CheckTaxTable()
        {
            if (taxTable == null || taxTable?.TaxTableItems.Count < 1)
                throw new Exception("Tax table was not generated!");
        }
    }
}
