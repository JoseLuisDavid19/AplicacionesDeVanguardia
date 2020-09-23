using System;
using System.Linq;

namespace Hotel.Rates.Core
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        IQueryable<TEntity> All();

        int SaveChanges();
    }
}
