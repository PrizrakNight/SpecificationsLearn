using SpecificationsLearn.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationsLearn.Specifications
{
    public abstract class Specification<TModel> : ISpecification<TModel>
        where TModel : ModelBase
    {
        protected Expression<Func<TModel, bool>> CombinedExpression
        {
            get
            {
                if (_combinedExpression == default)
                    _combinedExpression = GetSpecification();

                return _combinedExpression;
            }
        }

        private Expression<Func<TModel, bool>> _combinedExpression;

        public ISpecification<TModel> And(ISpecification<TModel> specification)
        {
            var parameter = Expression.Parameter(typeof(TModel), "ref_and_model");
            var expression = Expression.And(Expression.Invoke(CombinedExpression, parameter), Expression.Invoke(specification.ToExpression(), parameter));

            _combinedExpression = Expression.Lambda<Func<TModel, bool>>(expression, parameter);

            return this;
        }

        public ISpecification<TModel> Or(ISpecification<TModel> specification)
        {
            var parameter = Expression.Parameter(typeof(TModel), "ref_or_model");
            var expression = Expression.Or(Expression.Invoke(CombinedExpression, parameter), Expression.Invoke(specification.ToExpression(), parameter));

            _combinedExpression = Expression.Lambda<Func<TModel, bool>>(expression, parameter);

            return this;
        }

        public Expression<Func<TModel, bool>> ToExpression()
        {
            return CombinedExpression;
        }

        protected abstract Expression<Func<TModel, bool>> GetSpecification();
    }
}
