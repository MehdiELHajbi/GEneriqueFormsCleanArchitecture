using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Queries
{
    class GetListDataBesesQueryHandler : IRequestHandler<GetListDataBesesQuery, List<ListDataBasesVM>>
    {
        private readonly IAsyncRepository<DataBase> _dataBaseRepository;
        private readonly IMapper _mapper;

        public GetListDataBesesQueryHandler(IMapper mapper, IAsyncRepository<DataBase> dataBaseRepository)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
        }

        public async Task<List<ListDataBasesVM>> Handle(GetListDataBesesQuery request, CancellationToken cancellationToken)
        {
            var ListDataBase = await _dataBaseRepository.ListAllAsync();

            return _mapper.Map<List<ListDataBasesVM>>(ListDataBase);
        }
    }
}
