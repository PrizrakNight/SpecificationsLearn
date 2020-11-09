using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpecificationsLearn.RandomStringProvider
{
    public class RandomStringsProvider : IRandomStringsProvider
    {
        public async Task<string[]> GetRandomStringsAsync(int numberOfStrings)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://names.drycodes.com/" + numberOfStrings);
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<string[]>(jsonString);
            }
        }
    }
}
