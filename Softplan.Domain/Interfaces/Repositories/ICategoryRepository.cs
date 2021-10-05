using Softplan.Domain.Entities;
using System.Threading.Tasks;

namespace Softplan.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        public Task<CategoryEntity> SelectDefaultCategory();
    }
}
