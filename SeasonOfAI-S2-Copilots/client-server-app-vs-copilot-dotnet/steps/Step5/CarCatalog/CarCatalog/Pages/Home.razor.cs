using Microsoft.AspNetCore.Components;

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

        protected override void OnInitialized()
        {
            Cars = GetCars();
        }

        private List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { Make = "Toyota", Model = "Camry", Year = 2022 },
                new Car { Make = "Honda", Model = "Accord", Year = 2022 },
                new Car { Make = "Ford", Model = "Mustang", Year = 2022 }
            };
        }
    }
}
