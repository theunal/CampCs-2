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

        public GetBrandByIdHandler(IBrandDal brandDal, IMapper mapper)
        {
            this.brandDal = brandDal;
            this.mapper = mapper;
        }

        public async Task<GetBrandByIdResponse> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            await brandBusinessRules.BrandShouldExistWhenRequestes(request.Id);

            var result = await brandDal.GetAsync(x => x.Id == request.Id);
            return new GetBrandByIdResponse
            {
                GetBrandByIdDto = mapper.Map<GetBrandByIdDto>(result)
            };
        }
    }
}
