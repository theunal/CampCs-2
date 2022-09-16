using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandDal brandDal;

        public BrandBusinessRules(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await brandDal.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }

        public static Task BrandShouldExistWhenRequestes(Brand? brand)
        {
            if (brand is null) throw new BusinessException("Requested brand does not exists.");
            return Task.CompletedTask;
        }
    }
}
