using Microsoft.AspNetCore.Mvc;
using CarSite.Service.Interfaces;


namespace CarSite.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);
            return RedirectToAction("Error");
        }
    }
}
