using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HasOwner : Specification<Item>
    {
        protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        {
            return models.Where(i => i.HumanId != default);
        }
    }
}
