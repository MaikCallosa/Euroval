using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Euroval.Domain.Service
{
    public interface IServiceAsync<Tv, Te>
    {
        Task<IEnumerable<Tv>> GetAll();
        Task<Tv> GetOne(int id);
        Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate);
        Task<int> Add(Tv obj);
        Task<int> Update(Tv obj);
        Task<int> Remove(int id);
    }
}
