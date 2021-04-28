using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class WithoutOwner : Specification<Item>
    {
        protected override Expression<Func<Item, bool>> GetSpecification()
        {
            return item => item.HumanId == default;
        }
    }
}
