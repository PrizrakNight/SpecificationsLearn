using System.Text.Json.Serialization;

namespace SpecificationsLearn.RandomPersonProvider.Models
{
    public class JsonPerson
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public JsonName Name { get; set; }

        [JsonPropertyName("location")]
        public JsonLocation Location { get; set; }
    }
}
