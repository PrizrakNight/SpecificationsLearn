using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class SpecificTier : Specification<Item>
    {
        private readonly Tier _tier;

        public SpecificTier(Tier tier)
        {
            _tier = tier;
        }

        protected override Expression<Func<Item, bool>> GetSpecification()
        {
            return item => item.Tier == _tier;
        }
    }
}
