using System;

namespace Benchmarking.Application
{
    public class DateParser
    {
        public int GetYearFromDatTime(string DateTimeAsString)
        {
            var datetime = DateTime.Parse(DateTimeAsString);

            return datetime.Year;
        }
    }
}
