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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
                return false;

            _dataset.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<T> Insert(T item)
        {
            _dataset.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dataset.AnyAsync(prop => prop.Id.Equals(id));
        }

        public async Task<T> SelectById(int id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> Update(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                return null;

            _context.Entry(result).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();

            return item;
        }

    }
}