using Application.Contracts;
using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update
{


    public class UpdateDataBesesCommandHandler : IRequestHandler<UpdateDataBesesCommand, UpdateDataBesesCommandResponse>
    {
        private readonly IDataBaseRepository _dataBaseRepository;
        private readonly IMapper _mapper;

        public UpdateDataBesesCommandHandler(IMapper mapper, IDataBaseRepository dataBaseRepository)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
        }

        public async Task<UpdateDataBesesCommandResponse> Handle(UpdateDataBesesCommand request, CancellationToken cancellationToken)
        {

            Algorithme racine = new WorkFlowUpdateDataBase("Update Data Base");
            racine.context = new ContextUpdateDataBase(request, _dataBaseRepository);

            racine.Execute();
            var sdd = racine.context.Result;
            //var ctx = new ContextUpdateDataBase(request, _dataBaseRepository);
            // create response
            //var UpdateDataBesesCommandResponse = result.Result;
            //var required = result.RequiredFields.Select(f => f.PropertyName);

            return UpdateDataBesesCommandResponse;
        }
        public async Task<UpdateDataBesesCommandResponse> HandleV1(UpdateDataBesesCommand request, CancellationToken cancellationToken)
        {
            // Validattion request With ValidatinBehaviour => automatique

            // Verify if id existe in data Base
            var entity = await _dataBaseRepository.GetByIdAsync(request.idDataBase);
            if (entity == null)
            {
                //throw new NotFoundException(nameof(DataBase) + "=>" + nameof(request.idDataBase), request.idDataBase);
            }

            //  editing  Data
            entity.ConnetionName = request.ConnetionName;
            entity.NameDataBase = request.NameDataBase;
            entity.TypeDataBase = request.TypeDataBase;


            // Update data and Save
            await _dataBaseRepository.UpdateAsync(entity);

            // create response
            var UpdateDataBesesCommandResponse = new UpdateDataBesesCommandResponse();
            UpdateDataBesesCommandResponse.Message = "update ok  ";

            return UpdateDataBesesCommandResponse;
        }
    }

}
