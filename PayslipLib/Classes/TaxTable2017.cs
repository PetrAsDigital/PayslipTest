using PayslipLib.Interfaces;
using System.Collections.Generic;

namespace PayslipLib.Classes
{
    public class TaxTable2017 : ITaxTable
    {
        public TaxTable2017()
        {
            Super = 9;
            TaxTableItems = new List<ITaxTableItem>();
            TaxTableItems.Add(new TaxTableItem(1, 0, 18200, 0, 0));
            TaxTableItems.Add(new TaxTableItem(2, 18200, 37000, 0, 0.19));
            TaxTableItems.Add(new TaxTableItem(3, 37000, 80000, 3572, 32.5));
            TaxTableItems.Add(new TaxTableItem(4, 80000, 180000, 17547, 37));
            TaxTableItems.Add(new TaxTableItem(5, 180000, double.MaxValue, 54547, 45));
        }

        public double Super { get; }
        public List<ITaxTableItem> TaxTableItems { get; }
    }
}
