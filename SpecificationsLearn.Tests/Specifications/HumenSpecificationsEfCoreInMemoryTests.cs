using SpecificationsLearn.Specifications;
using SpecificationsLearn.Specifications.Implementation;
using SpecificationsLearn.Tests.Fixtures;
using System.Linq;
using Xunit;

namespace SpecificationsLearn.Tests.Specifications
{
    public class HumenSpecificationsEfCoreInMemoryTests : IClassFixture<EfCoreInMemoryFixture>
    {
        private readonly EfCoreInMemoryFixture _efCoreFixture;

        public HumenSpecificationsEfCoreInMemoryTests(EfCoreInMemoryFixture efCoreFixture)
        {
            _efCoreFixture = efCoreFixture;
        }

        [Fact]
        public void HumanIsDead_WithoutIncludeItems_ShouldReturnTwoWithoutItems()
        {
            var specification = new HumanIsDead();

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAll(specification);

            Assert.Equal(2, result.Length);
            Assert.True(result.All(h => h.Items == default));
        }

        [Fact]
        public void HumanIsLife_WithIncludeItems_ShouldReturnTwoWithItems()
        {
            var specification = new HumanIsLife().CombineWith<HumanIncludeItems>();

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAll(specification);

            Assert.Equal(2, result.Length);
            Assert.True(result.All(h => h.Items.Count > 0));
        }

        [Fact]
        public void HumanIncludeItems_ShouldReturnFourWithItemsNotNull()
        {
            var specification = new HumanIncludeItems();

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAll(specification);

            Assert.Equal(4, result.Length);
            Assert.True(result.All(h => h.Items != default));
        }
    }
}
