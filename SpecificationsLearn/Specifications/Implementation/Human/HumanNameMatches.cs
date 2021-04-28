using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HumanNameMatches : Specification<Human>
    {
        private readonly string _humanName;

        public HumanNameMatches(string humanName)
        {
            _humanName = humanName;
        }

        protected override Expression<Func<Human, bool>> GetSpecification()
        {
            return human => human.Name == _humanName;
        }
    }
}
