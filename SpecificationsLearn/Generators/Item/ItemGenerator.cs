using SpecificationsLearn.Models;
using System;

namespace SpecificationsLearn.Generators
{
    public class ItemGenerator : IModelGenerator<Item>
    {
        public Item Generate()
        {
            var random = new Random();
            var randomTier = (Tier)random.Next(1, 4);

            return new Item
            {
                Tier = randomTier,
            };
        }
    }
}
