using System.Threading.Tasks;

namespace SpecificationsLearn.RandomStringProvider
{
    public interface IRandomStringsProvider
    {
        Task<string[]> GetRandomStringsAsync(int numberOfStrings);
    }
}
