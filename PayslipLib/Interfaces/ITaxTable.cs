using System.Collections.Generic;

namespace PayslipLib.Interfaces
{
    public interface ITaxTable
    {
        List<ITaxTableItem> TaxTableItems { get; }
    }
}
