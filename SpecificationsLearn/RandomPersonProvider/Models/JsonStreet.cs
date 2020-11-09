using System.Text.Json.Serialization;

namespace SpecificationsLearn.RandomPersonProvider.Models
{
    public class JsonStreet
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
