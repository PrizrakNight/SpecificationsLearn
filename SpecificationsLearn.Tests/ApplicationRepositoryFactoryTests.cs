using SpecificationsLearn.Models;
using SpecificationsLearn.Repositories;
using SpecificationsLearn.Repositories.Implementation;
using Xunit;

namespace SpecificationsLearn.Tests
{
    public class ApplicationRepositoryFactoryTests
    {
        [Theory]
        [InlineData(RepositoryType.EfCore)]
        [InlineData(RepositoryType.InMemory)]
        [InlineData(RepositoryType.MongoDb)]
        public void CreateNew_HumanEntity_ShouldReturnImlementation(RepositoryType repositoryType)
        {
            var result = ApplicationRepositoryFactory.CreateNew<Human>(repositoryType);

            switch (repositoryType)
            {
                case RepositoryType.MongoDb:
                    Assert.IsType<MongoDbRepository<Human>>(result);
                    break;
                case RepositoryType.EfCore:
                    Assert.IsType<EfCoreRepository<Human>>(result);
                    break;
                case RepositoryType.InMemory:
                    Assert.IsType<InMemoryRepository<Human>>(result);
                    break;
            }
        }
    }
}
