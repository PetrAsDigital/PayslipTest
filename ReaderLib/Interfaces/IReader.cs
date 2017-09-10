using PayslipLib;
using System.Collections.Generic;

namespace ReaderLib
{
    public interface IReader
    {
        List<IPerson> ReadAllPersons(object content);
    }
}
