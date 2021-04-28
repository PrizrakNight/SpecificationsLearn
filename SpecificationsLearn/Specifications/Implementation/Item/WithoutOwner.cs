using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class WithoutOwner : Specification<Item>
    {
        //protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        //{
        //    return models.Where(i => i.HumanId == default);
        //}

        protected override Expression<Func<Item, bool>> GetSpecification()
        {
            return item => item.HumanId == default;
        }
    }
}
