using BackendTest.Models;
using System.Text.Json;

namespace BackendTest.Repositories
{
    public class Repository : IRepository<Customer>
    {
        private HttpClient _httpClient;
        private Customer? _customers;
        public Repository()
        {
            _httpClient = new HttpClient();
        }
        async private Task<string?> GetAPIData() {
            string url = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer";
            string token = "Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=";
            _httpClient.DefaultRequestHeaders.Add("Device", "POSTMAN");
            _httpClient.DefaultRequestHeaders.Add("Version", "2.0.6.0");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
            var result = await _httpClient.GetAsync(url);

            return await result.Content.ReadAsStringAsync();
        }
        private string FormatResponse(string body) {
            return body.Trim('"').Replace("\\\"", "\"").Replace("\\r\\n", "");
        }

        async Task<Customer?> IRepository<Customer>.Get()
        {
            var body = await GetAPIData();
            body = FormatResponse(body);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            try {
                _customers = JsonSerializer.Deserialize<Customer>(body, options);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
            return _customers;
        }


        
    }
}
