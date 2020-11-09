using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HumanIsDead : Specification<Human>
    {
        protected override IQueryable<Human> ApplySpecificationInternal(IQueryable<Human> models)
        {
            return models.Where(h => h.IsDead);
        }
    }
}
