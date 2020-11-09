using MongoDB.Driver;
using SpecificationsLearn.Models;
using SpecificationsLearn.Options;
using System.Linq;

namespace SpecificationsLearn.Repositories.Implementation
{
    public class MongoDbRepository<TModel> : IApplicationRepository<TModel>
        where TModel : ModelBase
    {
        private readonly IMongoCollection<TModel> _mongoCollection;

        public MongoDbRepository()
        {
            var options = DataSourceOptions.ReadFromFile();
            var client = new MongoClient(options.MongoDbDataProvider.MongoConnectionString);
            var database = client.GetDatabase(options.MongoDbDataProvider.MongoDbName);

            _mongoCollection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public IQueryable<TModel> AsQueryable()
        {
            return _mongoCollection.AsQueryable();
        }

        public void Delete(params TModel[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var filter = Builders<TModel>.Filter.Eq(m => m.Id, entities[i].Id);

                _mongoCollection.DeleteOne(filter);
            }
        }

        public void Insert(params TModel[] entities)
        {
            _mongoCollection.InsertMany(entities);
        }

        public void Update(params TModel[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var filter = Builders<TModel>.Filter.Eq(m => m.Id, entities[i].Id);

                _mongoCollection.ReplaceOne(filter, entities[i]);
            }
        }
    }
}
