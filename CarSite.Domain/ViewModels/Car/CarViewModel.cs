
namespace CarSite.Domain.ViewModels.Car
{
    public class CarViewModel
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Speed { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string Type { get; set; }
    }
}
