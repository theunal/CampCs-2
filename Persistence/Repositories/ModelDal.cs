using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ModelDal : EfRepositoryBase<Model, DataContext>, IModelDal
    {
        public ModelDal(DataContext context) : base(context)
        {
        }
    }
}
