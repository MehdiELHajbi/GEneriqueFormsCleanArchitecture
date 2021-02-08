using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarking.Application
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmark
    {
        private const string dateTime = "2020-02-07T14:30:30Z";
        public static readonly DateParser Parser = new DateParser();

        [Benchmark]
        public void GetYearFromDatTime()
        {
            Parser.GetYearFromDatTime(dateTime);
        }
    }
}
