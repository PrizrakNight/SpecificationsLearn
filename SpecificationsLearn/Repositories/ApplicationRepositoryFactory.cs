using SpecificationsLearn.Models;
using SpecificationsLearn.Repositories.Implementation;
using System;

namespace SpecificationsLearn.Repositories
{
    public static class ApplicationRepositoryFactory
    {
        public static IApplicationRepository<TModel> CreateNew<TModel>(RepositoryType repositoryType)
            where TModel : ModelBase
        {
            switch (repositoryType)
            {
                case RepositoryType.MongoDb: return new MongoDbRepository<TModel>();
                case RepositoryType.EfCore: return new EfCoreRepository<TModel>();
                case RepositoryType.InMemory: return new InMemoryRepository<TModel>();

                default: throw new InvalidOperationException("Unknown repository type");
            }
        }
    }
}
