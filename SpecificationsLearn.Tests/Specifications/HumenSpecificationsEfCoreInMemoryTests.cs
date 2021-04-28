using SpecificationsLearn.Specifications;
using SpecificationsLearn.Specifications.Implementation;
using SpecificationsLearn.Tests.Fixtures;
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
        public void HumanIsDead_ShouldReturnTwo()
        {
            var specification = new HumanIsDead();

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAllBySpec(specification);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void HumanIsLife_ShouldReturnTwo()
        {
            var specification = new HumanIsLife();

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAllBySpec(specification);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void HumanIsLifeOfDead_ShouldReturnFour()
        {
            var specification = new HumanIsLife().Or(new HumanIsDead());

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindAllBySpec(specification);

            Assert.Equal(4, result.Length);
        }

        [Fact]
        public void HumanNameMatches_ShouldReturnAdrianoGiudice()
        {
            var targetName = "Adriano Giudice";
            var specification = new HumanNameMatches(targetName);

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindBySpec(specification);

            Assert.NotNull(result);
            Assert.Equal(targetName, result.Name);
        }

        [Fact]
        public void HumanIsLifeAndMatchesName_ShouldReturnJohnSmith()
        {
            var targetName = "John Smith";
            var specification = new HumanIsLife().And(new HumanNameMatches(targetName));

            var result = _efCoreFixture.ApplicationDbContext.Humen.FindBySpec(specification);

            Assert.NotNull(result);
            Assert.Equal(targetName, result.Name);
        }
    }
}
