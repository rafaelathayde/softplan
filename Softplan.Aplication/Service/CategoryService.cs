using AutoMapper;
using Softplan.Domain.Dto.Category;
using Softplan.Domain.Interfaces.Repositories;
using Softplan.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Softplan.Aplication.Service
{
    public class CategoryService : ICategoryService
    {
        private static IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;            
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var _category = await _categoryRepository.SelectById(id);

            if (_category == null)
                _category = await _categoryRepository.SelectDefaultCategory();

            return _mapper.Map<CategoryDto>(_category);
        }
    }
}
