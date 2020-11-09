using SpecificationsLearn.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationsLearn.Repositories.Implementation
{
    public class InMemoryRepository<TModel> : IApplicationRepository<TModel>
        where TModel : ModelBase
    {
        private readonly ICollection<TModel> _models;

        public InMemoryRepository()
        {
            _models = new HashSet<TModel>();
        }

        public IQueryable<TModel> AsQueryable()
        {
            return _models.AsQueryable();
        }

        public void Delete(params TModel[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
                _models.Remove(entities[i]);
        }

        public void Insert(params TModel[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i].Id = GetActualId();

                _models.Remove(entities[i]);
            }
        }

        public void Update(params TModel[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var item = _models.FirstOrDefault(m => m.Id == entities[i].Id);

                if(item != default)
                {
                    _models.Remove(item);
                    _models.Add(entities[i]);
                }
            }
        }

        private int GetActualId()
        {
            var currentId = 1;
            var isUnique = false;

            do
            {
                if (_models.Any(m => m.Id == currentId))
                {
                    currentId++;
                    continue;
                }

                isUnique = true;
            }
            while (!isUnique);

            return currentId;
        }
    }
}
