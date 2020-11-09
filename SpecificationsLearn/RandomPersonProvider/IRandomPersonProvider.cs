using SpecificationsLearn.RandomPersonProvider.Models;
using System.Threading.Tasks;

namespace SpecificationsLearn.RandomPersonProvider
{
    public interface IRandomPersonProvider
    {
        Task<JsonPerson[]> GetPersonsAsync(int numberOfPersons);
    }
}
