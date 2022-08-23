using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public string Name { get; set; }
    }
}
