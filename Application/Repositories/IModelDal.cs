using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IModelDal : IAsyncRepository<Model>, IRepository<Model>
    {
    }
}
