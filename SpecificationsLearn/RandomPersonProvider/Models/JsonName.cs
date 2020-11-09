using System.Text.Json.Serialization;

namespace SpecificationsLearn.RandomPersonProvider.Models
{
    public class JsonName
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }

        public override string ToString()
        {
            return $"{Title}. {First} {Last}";
        }
    }
}
