using Microsoft.EntityFrameworkCore;
using Softplan.Data.Context;
using Softplan.Domain.Entities;
using Softplan.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> Insert(ProductEntity item)
        {
            try
            {
                _context.Product.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar o produto");
            }
        }

        public async Task<IEnumerable<ProductEntity>> SelectAll()
        {
            return await _context.Product.Include("Category").AsNoTracking().ToListAsync();
        }

        public Task<ProductEntity> SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> Update(ProductEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
