using System.Collections.Generic;

namespace PayslipLib
{
    public interface IPayCalc
    {
        List<IPerson> ProcessAllPersons(List<IPerson> allPersons);
    }
}