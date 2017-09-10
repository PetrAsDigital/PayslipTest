using PayslipLib.Interfaces;

namespace PayslipLib.Classes
{
    public class TaxTableItem : ITaxTableItem
    {
        public TaxTableItem(int orderNum, double minValue, double maxValue, double baseTax, double tax)
        {
            OrderNum = orderNum;
            MinValue = minValue;
            MaxValue = maxValue;
            BaseTax = baseTax;
            Tax = tax;
        }

        public int OrderNum { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        public double BaseTax { get; }
        public double Tax { get; }
    }
}
