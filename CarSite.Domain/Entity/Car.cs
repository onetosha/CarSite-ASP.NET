using CarSite.Domain.Enum;

namespace CarSite.Domain.Entity
{
    public class Car
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Speed { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeCar Type { get; set; }
    }
}
