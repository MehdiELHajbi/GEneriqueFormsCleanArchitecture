using Application.Contracts;
using Application.Features.Common.BaseResponse;
using Application.Features.DataBases.Commands.Create.Steps;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBesesCommandHandler : IRequestHandler<CreateDataBesesCommand, ResponseAbstract>
    {
        private readonly IDataBaseRepository _dataBaseRepository;
        private readonly IMapper _mapper;

        public CreateDataBesesCommandHandler(IMapper mapper, IDataBaseRepository dataBaseRepository)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
        }
        public async Task<ResponseAbstract> Handle(CreateDataBesesCommand request, CancellationToken cancellationToken)
        {

            var ctx = new Context();
            var build = new CreateDatabaseObjectStep(ctx, request, _dataBaseRepository);
            var json = JsonConvert.SerializeObject(build);
            //var exception = (Exception)build.OneOf[2];
            ctx = await build.Execute(ctx);

            //ctx.result = result.GetResult(ctx);

            return ctx.ResponseAbstract;
        }

        // Version 1 Handel
        //public async Task<CreateDataBesesCommandResponse> Handle(CreateDataBesesCommand request, CancellationToken cancellationToken)
        //{



        //    // Validattion request With ValidatinBehaviour => automatique

        //    // init data to save
        //    var dataBase = new DataBase()
        //    {
        //        ConnetionName = request.ConnetionName,
        //        NameDataBase = request.NameDataBase,
        //        TypeDataBase = request.TypeDataBase
        //    };

        //    // save data in data Base
        //    dataBase = await _dataBaseRepository.AddAsync(dataBase);

        //    // create response
        //    var CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse();
        //    CreateDataBesesCommandResponse.IdDataBase = dataBase.IdDataBase;
        //    CreateDataBesesCommandResponse.Message = "Create ok for id " + dataBase.IdDataBase;

        //    // Return Response
        //    return CreateDataBesesCommandResponse;
        //}

    }
}
