using System.Collections.Generic;

namespace PayslipLib.Interfaces
{
    public interface ITaxTable
    {
        double Super { get; }
        List<ITaxTableItem> TaxTableItems { get; }
    }
}
