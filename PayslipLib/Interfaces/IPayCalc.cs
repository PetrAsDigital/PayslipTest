using PayslipLib.Interfaces;
using System.Collections.Generic;

namespace PayslipLib
{
    public interface IPayCalc
    {
        ITaxTable GetTaxTable();
        List<IPerson> ProcessAllPersons(List<IPerson> allPersons);
    }
}