using Ninject;
using Ninject.Modules;
using PayslipLib;
using ReaderLib;
using ReaderLib.Classes;
using System.Reflection;

namespace PayslipApp
{
    public class NinjectBindings: NinjectModule
    {
        public static StandardKernel kernel;

        public static void InitNinject()
        {
            kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
        }

        public override void Load()
        {
            Bind<IReader>().To<CsvReader>();
            Bind<IPayCalc>().To<PayCalc_2017>();
        }
    }
}
