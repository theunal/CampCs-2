using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQueryRequest, GetListModelByDynamicQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IModelDal modelDal;

        public GetListModelByDynamicQueryHandler(IMapper mapper, IModelDal modelDal)
        {
            this.mapper = mapper;
            this.modelDal = modelDal;
        }

        public async Task<GetListModelByDynamicQueryResponse> Handle(GetListModelByDynamicQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await modelDal.GetListByDynamicAsync(
                request.Dynamic,
                include: x => x.Include(c => c.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
                );

            var mappedData = mapper.Map<GetListModelByDynamicQueryResponse>(result);
            return mappedData;
        }
    }
}
