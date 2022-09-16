using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQueryRequest, GetListModelQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IModelDal modelDal;

        public GetListModelQueryHandler(IMapper mapper, IModelDal modelDal)
        {
            this.mapper = mapper;
            this.modelDal = modelDal;
        }

        public async Task<GetListModelQueryResponse> Handle(GetListModelQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await modelDal.GetListAsync(
                include: x => x.Include(c => c.Brand),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
                );

            var mappedData = mapper.Map <GetListModelQueryResponse>(result);
            return mappedData;
        }
    }
}
