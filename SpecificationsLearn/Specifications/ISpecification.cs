using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications
{
    public interface ISpecification<TModel> where TModel : ModelBase
    {
        ISpecification<TModel> Combine(ISpecification<TModel> specification);
        ISpecification<TModel> CombineWith<TSpecification>() where TSpecification : ISpecification<TModel>, new();

        IQueryable<TModel> ApplySpecification(IQueryable<TModel> models);
    }
}
