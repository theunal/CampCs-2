using Application.Features.Brands.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQueryHandler :
        IRequestHandler<GetListBrandQueryRequest, GetListBrandQueryResponse>
    {
        private readonly IBrandDal brandDal;
        private readonly IMapper mapper;

        public GetListBrandQueryHandler(IMapper mapper, IBrandDal brandDal)
        {
            this.mapper = mapper;
            this.brandDal = brandDal;
        }



        public async Task<GetListBrandQueryResponse> Handle(GetListBrandQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await brandDal.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return new GetListBrandQueryResponse
            {
                BrandListModel = mapper.Map<BrandListModel>(result)
            };
        }
    }
}
