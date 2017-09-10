namespace PayslipLib.Interfaces
{
    public interface ITaxTableItem
    {
        int OrderNum { get; }
        double MinValue { get; }
        double MaxValue { get; }
        double BaseTax { get; }
        double Tax { get; }
    }
}
