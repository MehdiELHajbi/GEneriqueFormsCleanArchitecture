using Application.Features.Common.Models;
using MediatR;

namespace Application.Features.DataBases.Queries
{
    public class GetListDataBesesWithPaginationQuery : IRequest<PaginatedList<ListDataBasesDTO>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
