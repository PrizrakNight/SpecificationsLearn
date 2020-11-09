using SpecificationsLearn.RandomPersonProvider;
using SpecificationsLearn.RandomPersonProvider.Models;
using System.Threading.Tasks;
using Xunit;

namespace SpecificationsLearn.Tests.Providers
{
    public class RandomUserProviderTests
    {
        private readonly RandomUserProvider _randomUserProvider;

        public RandomUserProviderTests()
        {
            _randomUserProvider = new RandomUserProvider();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(15)]
        public async Task GetPersons_ShouldReturnNotNull(int count)
        {
            var result = await _randomUserProvider.GetPersonsAsync(count);

            Assert.Equal(count, result.Length);

            foreach (var person in result)
                ValidatePerson(person);
        }

        private void ValidatePerson(JsonPerson person)
        {
            Assert.False(string.IsNullOrWhiteSpace(person.Gender));

            Assert.NotNull(person.Name);
            Assert.False(string.IsNullOrWhiteSpace(person.Name.First));
            Assert.False(string.IsNullOrWhiteSpace(person.Name.Last));
            Assert.False(string.IsNullOrWhiteSpace(person.Name.Title));

            Assert.NotNull(person.Location);
            Assert.False(string.IsNullOrWhiteSpace(person.Location.City));

            Assert.NotNull(person.Location.Street);
            Assert.False(string.IsNullOrWhiteSpace(person.Location.Street.Name));
            Assert.False(person.Location.Street.Number == 0);
        }
    }
}
