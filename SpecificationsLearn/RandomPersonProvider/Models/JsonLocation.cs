using System.Text.Json.Serialization;

namespace SpecificationsLearn.RandomPersonProvider.Models
{
    public class JsonLocation
    {
        [JsonPropertyName("city")]
        public string City { get; set; }


        [JsonPropertyName("street")]
        public JsonStreet Street { get; set; }
    }
}
