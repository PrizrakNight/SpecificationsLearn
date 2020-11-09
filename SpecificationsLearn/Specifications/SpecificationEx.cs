using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications
{
    public static class SpecificationEx
    {
        public static TModel Find<TModel>(this IQueryable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            return specification.ApplySpecification(models).FirstOrDefault();
        }

        public static TModel[] FindAll<TModel>(this IQueryable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            if (specification == default) return models.ToArray();

            return specification.ApplySpecification(models).ToArray();
        }
    }
}
