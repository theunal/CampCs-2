using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBrandDal : IAsyncRepository<Brand>, IRepository<Brand>
    {
    }
}
