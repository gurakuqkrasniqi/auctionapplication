using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Domain.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IList<T>> FindListAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task<T> FindAsync(Expression<Func<T, bool>> predicte);

        Task SaveChangesAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> criteria);

        void Update(T entity);

        void Delete(int id);
    }
}
