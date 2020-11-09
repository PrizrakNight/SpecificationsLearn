using SpecificationsLearn.RandomPersonProvider.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpecificationsLearn.RandomPersonProvider
{
    public class RandomUserProvider : IRandomPersonProvider
    {
        private const string _urlBase = "https://randomuser.me/api/?inc=gender,name,location";

        public async Task<JsonPerson[]> GetPersonsAsync(int numberOfPersons)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{_urlBase}&results={numberOfPersons}");
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<JsonPerson[]>(JsonDocument.Parse(jsonString).RootElement.GetProperty("results").ToString());
            }
        }
    }
}
