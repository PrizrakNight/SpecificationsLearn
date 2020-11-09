using SpecificationsLearn.Models;

namespace SpecificationsLearn.Repositories
{
    public interface IApplicationUnitOfWork
    {
        IApplicationRepository<Human> Humans { get; set; }
        IApplicationRepository<Item> Items { get; set; }
    }
}
