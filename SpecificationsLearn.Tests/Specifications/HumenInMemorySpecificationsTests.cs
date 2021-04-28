using SpecificationsLearn.Models;
using SpecificationsLearn.Specifications;
using SpecificationsLearn.Specifications.Implementation;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SpecificationsLearn.Tests.Specifications
{
    public class HumenInMemorySpecificationsTests
    {
        private readonly Human[] _humen =
        {
            new Human
                {
                    IsDead = false,
                    Name = "John Smith",
                    Items = new HashSet<Item>
                    {
                        new Item
                        {
                            Tier = Tier.White,
                            Title = "White item 2"
                        },
                        new Item
                        {
                            Tier = Tier.Blue,
                            Title = "Blue item 2"
                        }
                    }
                },
                new Human
                {
                    IsDead = false,
                    Name = "Adriano Giudice",
                    Items = new HashSet<Item>
                    {
                        new Item
                        {
                            Tier = Tier.Purple,
                            Title = "Purple item 1"
                        },
                        new Item
                        {
                            Tier = Tier.Purple,
                            Title = "Purple item 2"
                        }
                    }
                },
                new Human
                {
                    IsDead = true,
                    Name = "Dead Man"
                },
                new Human
                {
                    IsDead = true,
                    Name = "Dead Man 2"
                }
        };

        [Fact]
        public void HumanIsLifeAndMatchesName_ShouldReturnJohnSmith()
        {
            var targetName = "John Smith";
            var specification = new HumanIsLife().And(new HumanNameMatches(targetName));

            var result = _humen.FindBySpec(specification);

            Assert.NotNull(result);
            Assert.Equal(targetName, result.Name);
        }

        [Fact]
        public void HumanIsLife_ShouldReturnTwo()
        {
            var specification = new HumanIsLife();

            var result = _humen.FindAllBySpec(specification);

            Assert.Equal(2, result.Length);
        }
    }
}
