using MediatR;
using System.Collections.Generic;

namespace Application.Features.DataBases.Queries
{
    public class GetListDataBesesQuery : IRequest<List<ListDataBasesVM>>
    {
    }
}
