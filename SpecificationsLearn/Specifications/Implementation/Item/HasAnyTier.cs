using SpecificationsLearn.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HasAnyTier : Specification<Item>
    {
        private readonly Tier[] _tiers;

        public HasAnyTier(params Tier[] tiers)
        {
            _tiers = tiers;
        }

        protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        {
            var result = new List<Item>();

            for (int i = 0; i < _tiers.Length; i++)
                result.AddRange(models.Where(item => item.Tier == _tiers[i]));

            return result.AsQueryable();
        }
    }
}
