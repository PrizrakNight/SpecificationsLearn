using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Repositories
{
    public interface IApplicationRepository<TEntity>
        where TEntity : ModelBase
    {
        IQueryable<TEntity> AsQueryable();

        void Insert(params TEntity[] entities);
        void Delete(params TEntity[] entities);
        void Update(params TEntity[] entities);
    }
}
