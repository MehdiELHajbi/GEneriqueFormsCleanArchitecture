namespace Benchmarking
{
    using BenchmarkDotNet.Running;
    using Benchmarking.Application.Feature.DataBases.Command.Create;
    using static Testing;
    class Program
    {
        static void Main(string[] args)
        {
            RunBeforeAnyTests();
            //ResetState();

            //await SendAsync(new CreateDataBesesCommand
            //{
            //    ConnetionName = "New Listss",
            //    NameDataBase = "NameDataBase",
            //    TypeDataBase = "TypeDataBase"
            //});

            BenchmarkRunner.Run<CreateDataBaseBenchmark>();
        }
    }
}

//powerShel

//    go to diretory of project 
//    build release
//    run benchmark.dll
