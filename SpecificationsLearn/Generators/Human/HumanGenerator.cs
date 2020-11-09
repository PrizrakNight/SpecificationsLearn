using SpecificationsLearn.Models;
using SpecificationsLearn.RandomStringProvider;
using System;
using System.Collections.Generic;

namespace SpecificationsLearn.Generators
{
    public class HumanGenerator : IModelGenerator<Human>
    {
        private readonly IRandomStringsProvider _randomStringProvider;
        private readonly IModelGenerator<Item> _itemGenerator;

        public HumanGenerator()
        {
            _itemGenerator = new ItemGenerator();
            _randomStringProvider = new RandomStringsProvider();
        }

        public Human Generate()
        {
            var random = new Random();
            var human = new Human();
            var countItems = random.Next(0, 10);
            var itemNames = _randomStringProvider.GetRandomStringsAsync(countItems).Result;

            human.Items = new HashSet<Item>();
            human.IsDead = Convert.ToBoolean(random.Next(0, 2));

            for (int i = 0; i < countItems; i++)
            {
                var item = _itemGenerator.Generate();

                item.Human = human;
                item.Title = itemNames[i];

                human.Items.Add(item);
            }

            return human;
        }
    }
}
