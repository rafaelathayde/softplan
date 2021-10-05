using Softplan.Domain.Entities;
using Softplan.Domain.Enum;
using Softplan.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftPlan.Tests.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private List<CategoryEntity> _category;
        public FakeCategoryRepository()
        {
            _category = new List<CategoryEntity>();
            _category.Add(new CategoryEntity(1, "Brinquedos", 0.25));
            _category.Add(new CategoryEntity(2, "Bebidas", 0.3));
            _category.Add(new CategoryEntity(3, "Informática", 0.1));
            _category.Add(new CategoryEntity(4, "Softplan", 0.05));
            _category.Add(new CategoryEntity(5, "Toda e qualquer outra categoria informada", 0.15));
            
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryEntity> Insert(CategoryEntity item)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CategoryEntity>> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CategoryEntity> SelectById(int id)
        {   
            return await Task.Run(() => _category.SingleOrDefault(a => a.Id == id));
        }

        public async Task<CategoryEntity> SelectDefaultCategory()
        {
            return await Task.Run(() => _category.FirstOrDefault(a => a.Id == (int)CategoryEnum.OutraCategoriaInformada));  
        }

        public Task<CategoryEntity> Update(CategoryEntity item)
        {
            throw new System.NotImplementedException();
        }
    }
}
