using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdRequest, GetBrandByIdResponse>
    {
        private readonly IBrandDal brandDal;
        private readonly IMapper mapper;
        private readonly BrandBusinessRules brandBusinessRules;

        public GetBrandByIdHandler(IBrandDal brandDal, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            this.brandDal = brandDal;
            this.mapper = mapper;
            this.brandBusinessRules = brandBusinessRules;
        }

        public async Task<GetBrandByIdResponse> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await brandDal.GetAsync(x => x.Id == request.Id);

            // iş kuralı
            await BrandBusinessRules.BrandShouldExistWhenRequestes(result);

            return mapper.Map<GetBrandByIdResponse>(result);
        }
    }
}
