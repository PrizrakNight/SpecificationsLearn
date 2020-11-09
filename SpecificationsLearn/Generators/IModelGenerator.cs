using SpecificationsLearn.Models;

namespace SpecificationsLearn.Generators
{
    public interface IModelGenerator<TModel> where TModel : ModelBase
    {
        TModel Generate();
    }
}
