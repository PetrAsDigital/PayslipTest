using System;

namespace PayslipLib
{
    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        int Salary { get; }
        double SuperRate { get; }
        DateTime PaymentStartDate { get; }
        DateTime PaymentEndDate { get; }

        int PayPeriod { get; }
        double GrossIncome { get; }
        double IncomeTax { get; }
        double NetIncome { get; }
        double Super { get; }

        IPerson SetPayPeriod(int payPeriod);
        IPerson SetGrossIncome(double grossIncome);
        IPerson SetIncomeTax(double incomeTax);
        IPerson SetNetIncome(double netIncome);
        IPerson SetSuper(double super);
    }
}
