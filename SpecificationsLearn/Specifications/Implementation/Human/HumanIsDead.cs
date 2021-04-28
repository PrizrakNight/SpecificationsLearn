using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class HumanIsDead : Specification<Human>
    {
        //protected override IQueryable<Human> ApplySpecificationInternal(IQueryable<Human> models)
        //{
        //    return models.Where(h => h.IsDead);
        //}

        protected override Expression<Func<Human, bool>> GetSpecification()
        {
            return human => human.IsDead;
        }
    }
}
