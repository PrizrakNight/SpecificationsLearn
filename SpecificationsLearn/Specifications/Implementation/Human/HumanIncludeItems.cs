using Microsoft.EntityFrameworkCore;
using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HumanIncludeItems : Specification<Human>
    {
        protected override IQueryable<Human> ApplySpecificationInternal(IQueryable<Human> models)
        {
            return models.Include(m => m.Items);
        }
    }
}
