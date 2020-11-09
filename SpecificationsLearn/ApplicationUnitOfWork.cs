using SpecificationsLearn.Models;
using SpecificationsLearn.Repositories;
using SpecificationsLearn.Repositories.Implementation;

namespace SpecificationsLearn
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        public IApplicationRepository<Human> Humans { get; set; } = new EfCoreRepository<Human>();
        public IApplicationRepository<Item> Items { get; set; } = new EfCoreRepository<Item>();
    }
}
