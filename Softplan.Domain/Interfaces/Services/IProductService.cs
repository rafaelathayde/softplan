using Softplan.Domain.Dto.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Domain.Command;

namespace Softplan.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDto> Get(int id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<GenericResult> Create(ProductCreateDto productCreateDto);
    }
}
