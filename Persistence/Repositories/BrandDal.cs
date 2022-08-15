using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandDal : EfRepositoryBase<Brand, DataContext>, IBrandDal
    {
        public BrandDal(DataContext context) : base(context)
        {
        }
    }
}
