using SpecificationsLearn.RandomStringProvider;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SpecificationsLearn.Tests.Providers
{
    public class RandomStringsProviderTests
    {
        private readonly RandomStringsProvider _randomStringsProvider;

        public RandomStringsProviderTests()
        {
            _randomStringsProvider = new RandomStringsProvider();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(15)]
        public async Task GetRandomStrings_ShouldReturnNotEmpty(int count)
        {
            var result = await _randomStringsProvider.GetRandomStringsAsync(count);

            Assert.Equal(count, result.Length);
            Assert.False(result.All(s => string.IsNullOrWhiteSpace(s)));
        }
    }
}
