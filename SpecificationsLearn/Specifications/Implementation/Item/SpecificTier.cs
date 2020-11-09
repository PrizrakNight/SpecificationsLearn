using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class SpecificTier : Specification<Item>
    {
        private readonly Tier _tier;

        public SpecificTier(Tier tier)
        {
            _tier = tier;
        }

        protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        {
            return models.Where(i => i.Tier == _tier);
        }
    }
}
