using SpecificationsLearn.Models;
using SpecificationsLearn.Specifications;
using SpecificationsLearn.Specifications.Implementation;
using SpecificationsLearn.Tests.Fixtures;
using System.Linq;
using Xunit;

namespace SpecificationsLearn.Tests.Specifications
{
    public class ItemsSpecificationsEfCoreInMemoryTests : IClassFixture<EfCoreInMemoryFixture>
    {
        private readonly EfCoreInMemoryFixture _efCoreFixture;

        public ItemsSpecificationsEfCoreInMemoryTests(EfCoreInMemoryFixture efCoreFixture)
        {
            _efCoreFixture = efCoreFixture;
        }

        [Fact]
        public void WithoutOwner_ShouldReturnTwoItems()
        {
            var specification = new WithoutOwner();

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void HasOwner_ShouldReturnFourItems()
        {
            var specification = new HasOwner();

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(4, result.Length);
        }

        [Fact]
        public void HasAnyTier_ShouldReturnFour()
        {
            var specification = new HasAnyTier(Tier.Blue, Tier.Purple);

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(4, result.Length);
        }

        [Fact]
        public void SpecificTier_ShouldReturnOnlyPurple()
        {
            var specification = new SpecificTier(Tier.Purple);

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.True(result.All(i => i.Tier == Tier.Purple));
        }

        [Fact]
        public void WithOwner_ShouldReturnTwoItems()
        {
            var owner = _efCoreFixture.ApplicationDbContext.Humen.First(h => h.Name == "John Smith");
            var specification = new WithOwner(owner);

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void WithOwners_ShouldReturnFourItems()
        {
            var owner = _efCoreFixture.ApplicationDbContext.Humen.First(h => h.Name == "John Smith");
            var owner2 = _efCoreFixture.ApplicationDbContext.Humen.First(h => h.Name == "Adriano Giudice");
            var specification = new WithOwners(owner, owner2);

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(4, result.Length);
        }

        [Fact]
        public void WithOwnerAndSpecificTier_ShouldReturnOne()
        {
            var owner = _efCoreFixture.ApplicationDbContext.Humen.First(h => h.Name == "John Smith");
            var specification = new WithOwner(owner).Combine(new SpecificTier(Tier.White));

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Single(result);
        }

        [Fact]
        public void WithOwnerAndHasAnyTier_ShouldReturnTwoItems()
        {
            var owner = _efCoreFixture.ApplicationDbContext.Humen.First(h => h.Name == "John Smith");
            var specification = new WithOwner(owner).Combine(new HasAnyTier(Tier.White, Tier.Blue));

            var result = _efCoreFixture.ApplicationDbContext.Items.FindAll(specification);

            Assert.Equal(2, result.Length);
        }
    }
}
