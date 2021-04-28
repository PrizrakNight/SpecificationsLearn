using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications
{
    public interface ISpecification<TModel> where TModel : ModelBase
    {
        ISpecification<TModel> And(ISpecification<TModel> specification);
        ISpecification<TModel> Or(ISpecification<TModel> specification);

        Expression<Func<TModel, bool>> ToExpression();
    }
}
