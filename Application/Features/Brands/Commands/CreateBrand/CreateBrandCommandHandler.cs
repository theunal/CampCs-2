using Application.Features.Brands.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler :
        IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandDal brandDal;
        private readonly IMapper mapper;
        private readonly BrandBusinessRules brandBusinessRules;

        public CreateBrandCommandHandler(IBrandDal brandDal, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            this.brandDal = brandDal;
            this.mapper = mapper;
            this.brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

            var mappedBrand = mapper.Map<Brand>(request);
            var createdBrand = await brandDal.AddAsync(mappedBrand);
            return mapper.Map<CreateBrandCommandResponse>(createdBrand);
        }
    }
}
