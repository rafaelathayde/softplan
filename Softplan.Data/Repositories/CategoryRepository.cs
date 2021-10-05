using Microsoft.EntityFrameworkCore;
using Softplan.Data.Context;
using Softplan.Domain.Entities;
using Softplan.Domain.Enum;
using Softplan.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryEntity> Insert(CategoryEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryEntity>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryEntity> SelectById(int id)
        {
           return await _context.Category.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<CategoryEntity> SelectDefaultCategory()
        {
            return await _context.Category.SingleOrDefaultAsync(a => a.Id == (int)CategoryEnum.OutraCategoriaInformada);
        }

        public Task<CategoryEntity> Update(CategoryEntity item)
        {
            throw new NotImplementedException();
        }
    }
}

