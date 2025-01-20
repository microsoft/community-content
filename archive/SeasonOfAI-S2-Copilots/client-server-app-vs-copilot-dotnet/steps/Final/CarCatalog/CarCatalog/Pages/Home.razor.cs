using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace CarCatalog.Pages
{
    public partial class Home : ComponentBase
    {
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
        }

        public List<Car> Cars { get; set; } = new List<Car>();

        protected override async Task OnInitializedAsync()
        {
            Cars = await GetCarsAsync();
        }

        private async Task<List<Car>> GetCarsAsync()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7071/api/cars");
            response.EnsureSuccessStatusCode();
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var json = await response.Content.ReadAsStringAsync();
            var cars = JsonSerializer.Deserialize<List<Car>>(json, jsonOptions);
            return cars;
        }
    }
}
