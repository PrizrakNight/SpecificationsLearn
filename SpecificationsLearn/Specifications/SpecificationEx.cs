using SpecificationsLearn.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationsLearn.Specifications
{
    public static class SpecificationEx
    {
        public static TModel FindBySpec<TModel>(this IQueryable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            if (specification == default)
                return default;

            return models.FirstOrDefault(specification.ToExpression());
        }

        public static TModel FindBySpec<TModel>(this IEnumerable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            if (specification == default)
                return default;

            return models.FirstOrDefault(specification.ToExpression().Compile());
        }

        public static TModel[] FindAllBySpec<TModel>(this IEnumerable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            if (specification == default) return models.ToArray();

            return models.Where(specification.ToExpression().Compile()).ToArray();
        }

        public static TModel[] FindAllBySpec<TModel>(this IQueryable<TModel> models, ISpecification<TModel> specification)
            where TModel : ModelBase
        {
            if (specification == default) return models.ToArray();

            return models.Where(specification.ToExpression()).ToArray();
        }
    }
}
