using CarSite.DAL.Interfaces;
using CarSite.Domain.Entity;
using CarSite.Domain.Response;
using CarSite.Service.Interfaces;
using CarSite.Domain.Enum;

namespace CarSite.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarReprository _carReprository;
        public CarService(ICarReprository carReprository)
        {
            _carReprository = carReprository;
        }

        

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();
            try
            {
                var cars = await _carReprository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                { 
                    Description = $"[GetCars] : {ex.Message}"
                };

            }
        }
    }
}
