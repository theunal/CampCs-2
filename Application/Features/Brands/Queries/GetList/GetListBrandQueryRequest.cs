using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQueryRequest : IRequest<GetListBrandQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}
