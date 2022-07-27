using CarSite.Domain.Entity;
using CarSite.Domain.Response;

namespace CarSite.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
    }
}
