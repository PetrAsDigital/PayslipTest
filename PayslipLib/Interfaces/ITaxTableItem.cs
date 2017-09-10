namespace PayslipLib.Interfaces
{
    public interface ITaxTableItem
    {
        int OrderNum { get; }           // just an order number
        double MinValue { get; }        // min. value from the range, e.g. $37000 in case of a range $37000-$80000
        double MaxValue { get; }        // max. value from the range, e.g. $80000 in case of a range $37000-$80000
        double BaseTax { get; }         // tax base for a particular range, e.g. $3572 
        double Tax { get; }             // tax in cents per 1 dolar, e.g. 32.5
    }
}
