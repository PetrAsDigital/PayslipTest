using CommonLib;
using PayslipLib;
using System;
using System.Collections.Generic;

namespace ReaderLib.Classes
{
    public class CsvReader : IReader
    {
        public List<IPerson> ReadAllPersons(object content)
        {
            if (!(content is string[]))
                throw new Exception("File content is not a csv type!");

            var csvContent = (string[])content;

            var result = new List<IPerson>();

            for (int i = 1; i < csvContent.Length; i++)
            {
                var data = csvContent[i].Split(',');

                var firstName = data[0];
                var lastName = data[1];
                var salary = Common.ConvertToInt(data[2]);
                var superRate = Common.ConvertToDouble(data[3]);
                var paymentStartDate = Common.ConvertToDateTime(data[4]);
                var paymentEndDate = Common.ConvertToDateTime(data[5]);

                var person = new Person(firstName, lastName, salary, superRate, paymentStartDate, paymentEndDate);
                result.Add(person);
            }

            return result;
        }
    }
}
