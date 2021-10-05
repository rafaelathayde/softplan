using Softplan.Domain.Dto.Category;
using System.Threading.Tasks;

namespace Softplan.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> Get(int id);
    }
}
