using Application.Features.DataBases.Commands.Create;
using Application.Features.DataBases.Queries;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Threading.Tasks;

namespace Benchmarking.Application.Feature.DataBases.Command.Create
{
    using static Testing;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CreateDataBaseBenchmark
    {
        //[Benchmark]
        //public async Task ShouldCreateTodoItem()
        //{

        //    var sync = await SendAsync(new CreateDataBesesCommand
        //    {
        //        ConnetionName = "New List",
        //        NameDataBase = "NameDataBase",
        //        TypeDataBase = "TypeDataBase"
        //    }); ;
        //}

        [Benchmark]
        public void CreateDataBesesCommand()
        {
            //Thread.Sleep(2000);

            var x = Task.FromResult(SendAsync(new CreateDataBesesCommand
            {
                ConnetionName = "New Listss",
                NameDataBase = "NameDataBase",
                TypeDataBase = "TypeDataBase"
            })).Result;
            Console.WriteLine(x.IsCompleted);

            //Task.FromResult(SendAsync(new CreateDataBesesCommand
            //{
            //    ConnetionName = "New Listss",
            //    NameDataBase = "NameDataBase",
            //    TypeDataBase = "TypeDataBase"
            //})).Wait();

            //await SendAsync(new CreateDataBesesCommand
            //{
            //    ConnetionName = "New Listss",
            //    NameDataBase = "NameDataBase",
            //    TypeDataBase = "TypeDataBase"
            //});
            //Thread.Sleep(2000);

        }

        //[Benchmark]
        public void GetListDataBesesQuery()
        {

            //Task.FromResult(SendAsync(new GetListDataBesesQuery())).Wait();


            var x = Task.FromResult(SendAsyncWithRepsonse(new GetListDataBesesQuery())).Result;
            Console.WriteLine(x.IsCompleted);
        }


    }
}
