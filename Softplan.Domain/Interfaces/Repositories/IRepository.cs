using Softplan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softplan.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T item);

        Task<T> Update(T item);

        Task<bool> Delete(int id);

        Task<T> SelectById(int id);

        Task<IEnumerable<T>> SelectAll();
    }
}
