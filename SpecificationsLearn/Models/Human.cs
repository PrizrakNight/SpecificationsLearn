using System.Collections.Generic;

namespace SpecificationsLearn.Models
{
    public class Human : ModelBase
    {
        public string Name { get; set; }

        public bool IsDead { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
