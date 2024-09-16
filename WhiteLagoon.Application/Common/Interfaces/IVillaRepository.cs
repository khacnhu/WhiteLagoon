using System.Linq.Expressions;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Common.Interfaces
{
    public interface IVillaRepository : IRepository<Villa>
    {

        //IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null);
        //Villa Get(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null);
        //void Add(Villa villa);
        void Update(Villa villa);
        //void Remove(Villa villa);
        void Save();

    }
}
