using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelByDynamicQueryRequest : IRequest<GetListModelByDynamicQueryResponse>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
