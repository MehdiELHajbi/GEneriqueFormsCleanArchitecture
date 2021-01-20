using Application.Contracts;
using Application.Features.Common.Models;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Queries
{
    class GetListDataBesesWithPaginationQueryHandler : IRequestHandler<GetListDataBesesWithPaginationQuery, PaginatedList<ListDataBasesDTO>>
    {
        private readonly IAsyncRepository<DataBase> _dataBaseRepository;
        private readonly IMapper _mapper;

        public GetListDataBesesWithPaginationQueryHandler(IMapper mapper, IAsyncRepository<DataBase> dataBaseRepository)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
        }

        public async Task<PaginatedList<ListDataBasesDTO>> Handle(GetListDataBesesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var list = await _dataBaseRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            var item = _mapper.Map<List<ListDataBasesDTO>>(list);
            var count = await _dataBaseRepository.CountAsync();

            return new PaginatedList<ListDataBasesDTO>(item, count, request.PageNumber, request.PageSize);
            //return new ListDataBasesWithPaginationVM(item, count, request.PageNumber, request.PageSize);


        }
    }
}
