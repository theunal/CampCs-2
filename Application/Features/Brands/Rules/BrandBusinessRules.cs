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

        public async Task BrandShouldExistWhenRequestes(int id)
        {
            var result = await brandDal.GetAsync(x => x.Id == id);
            if (result is null) throw new BusinessException("Requested brand does not exists.");
        }
    }
}
