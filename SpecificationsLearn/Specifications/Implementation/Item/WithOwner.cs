using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class WithOwner : Specification<Item>
    {
        private readonly int _humanId;

        public WithOwner(Human human)
        {
            _humanId = human.Id;
        }

        public WithOwner(int humanId)
        {
            _humanId = humanId;
        }

        protected override Expression<Func<Item, bool>> GetSpecification()
        {
            return item => item.HumanId == _humanId;
        }
    }
}
