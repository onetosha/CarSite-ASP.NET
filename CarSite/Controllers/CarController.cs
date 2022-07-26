using CarSite.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CarSite.Domain.Entity;


namespace CarSite.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarReprository _carReprository;
        public CarController(ICarReprository carReprository)
        {
            _carReprository = carReprository;
        }

        public async Task<IActionResult> GetCars()
        {
            var response = await _carReprository.Select();
            var response1 = await _carReprository.GetByName("VAZ");
            var response2 = await _carReprository.Get(3);

            var car = new Car()
            {
                id = 4,
                Name = "Machine",
                Model = "Good",
                Speed = 150,
                Price = 150030,
                Description = "CarEntityDescription",
                DateCreate = DateTime.Now
            };

            await _carReprository.Create(car);
            await _carReprository.Delete(car);
            return View(response);
        }
    }
}
