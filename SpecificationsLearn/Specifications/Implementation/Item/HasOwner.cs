using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HasOwner : Specification<Item>
    {
        protected override Expression<Func<Item, bool>> GetSpecification()
        {
            return item => item.HumanId.HasValue;
        }
    }
}
