using Microsoft.EntityFrameworkCore;
using SpecificationsLearn.Models;
using SpecificationsLearn.RelationalDatabase;
using System;
using System.Collections.Generic;

namespace SpecificationsLearn.Tests.Fixtures
{
    public sealed class EfCoreInMemoryFixture
    {
        public readonly ApplicationDbContext ApplicationDbContext;

        public EfCoreInMemoryFixture()
        {
            ApplicationDbContext = new ApplicationDbContext(GetContextOptions());
            ApplicationDbContext.Database.EnsureCreated();

            FillDatabase();
        }

        private DbContextOptions<ApplicationDbContext> GetContextOptions()
        {
            var random = new Random();

            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DefaultDbForTests_"+ random.Next())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }

        private void FillDatabase()
        {
            var items = new Item[]
            {
                new Item
                {
                    Tier = Tier.White,
                    Title = "White item 1"
                },
                new Item
                {
                    Tier = Tier.Blue,
                    Title = "Blue item 1"
                },
            };

            var humen = new Human[]
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
                },
            };

            ApplicationDbContext.Humen.AddRange(humen);
            ApplicationDbContext.Items.AddRange(items);
            ApplicationDbContext.SaveChanges();
        }
    }
}
