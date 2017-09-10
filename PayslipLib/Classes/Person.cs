using System;

namespace PayslipLib
{
    public class Person: IPerson
    {
        #region Constructor

        public Person(string firstName, string lastName, int salary, double superRate, 
            DateTime paymentStartDate, DateTime paymentEndDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            SuperRate = superRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
        }

        #endregion Constructor

        #region Private

        private int _payPeriod;
        private double _grossIncome;
        private double _incomeTax;
        private double _netIncome;
        private double _super;

        #endregion Private

        #region Public

        public string FirstName { get; }
        public string LastName { get; }
        public int Salary { get; }
        public double SuperRate { get; }
        public DateTime PaymentStartDate { get; }
        public DateTime PaymentEndDate { get; }

        public int PayPeriod { get { return _payPeriod; } }
        public double GrossIncome { get { return _grossIncome; } }
        public double IncomeTax { get { return _incomeTax; } }
        public double NetIncome { get { return _netIncome; } }
        public double Super { get { return _super; } }

        #endregion Public

        #region Implementation

        public IPerson SetPayPeriod(int payPeriod)
        {
            _payPeriod = payPeriod;
            return this;
        }

        public IPerson SetGrossIncome(double grossIncome)
        {
            _grossIncome = grossIncome;
            return this;
        }

        public IPerson SetIncomeTax(double incomeTax)
        {
            _incomeTax = incomeTax;
            return this;
        }

        public IPerson SetNetIncome(double netIncome)
        {
            _netIncome = netIncome;
            return this;
        }

        public IPerson SetSuper(double super)
        {
            _super = super;
            return this;
        }

        #endregion Implementation
    }
}
