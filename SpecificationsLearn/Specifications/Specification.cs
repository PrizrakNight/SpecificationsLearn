using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications
{
    public abstract class Specification<TModel> : ISpecification<TModel>
        where TModel : ModelBase
    {
        private ISpecification<TModel> _specification;

        public IQueryable<TModel> ApplySpecification(IQueryable<TModel> models)
        {
            models = ApplySpecificationInternal(models);

            if (_specification != default)
                models = _specification.ApplySpecification(models);

            return models;
        }

        public ISpecification<TModel> Combine(ISpecification<TModel> specification)
        {
            if (_specification == default) _specification = specification;
            else _specification.Combine(specification);

            return this;
        }

        public ISpecification<TModel> CombineWith<TSpecification>() where TSpecification : ISpecification<TModel>, new()
        {
            Combine(new TSpecification());

            return this;
        }

        public static ISpecification<TModel> Create<TSpecification>()
            where TSpecification : ISpecification<TModel>, new()
        {
            return new TSpecification();
        }

        protected abstract IQueryable<TModel> ApplySpecificationInternal(IQueryable<TModel> models);
    }
}
