namespace SpecificationsLearn.Models
{
    public enum Tier { White = 1, Blue, Purple }

    public class Item : ModelBase
    {
        public string Title { get; set; }

        public Tier Tier { get; set; }

        public int? HumanId { get; set; }

        public Human Human { get; set; }
    }
}
