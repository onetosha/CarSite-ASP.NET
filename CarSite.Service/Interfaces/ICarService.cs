using CarSite.Domain.Entity;
using CarSite.Domain.Response;
using CarSite.Domain.ViewModels.Car;

namespace CarSite.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<Car>> EditCar(int id, CarViewModel carViewModel);
    }
}
