using MediatR;

namespace Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdRequest : IRequest<GetBrandByIdResponse>
    {
        public int Id { get; set; }
    }
}
