using Application.Features.Models.Dtos;
using Application.Features.Models.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>()
                .ForMember(x => x.BrandName, opt => opt.MapFrom(y => y.Brand.Name)).ReverseMap();
            CreateMap<GetListModelQueryResponse, IPaginate<Model>>().ReverseMap();
            CreateMap<GetListModelByDynamicQueryResponse, IPaginate<Model>>().ReverseMap();
        }
    }
}
