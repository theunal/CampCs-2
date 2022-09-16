using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQueryRequest : IRequest<GetListModelQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}
