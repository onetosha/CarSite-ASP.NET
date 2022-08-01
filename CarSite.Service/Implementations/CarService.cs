using CarSite.DAL.Interfaces;
using CarSite.Domain.Entity;
using CarSite.Domain.Response;
using CarSite.Service.Interfaces;
using CarSite.Domain.Enum;
using CarSite.Domain.ViewModels.Car;

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
                    return baseResponse;
                }
                baseResponse.Data = cars;
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

        public async Task<IBaseResponse<Car>> GetCar(int id) 
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carReprository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = car;
                return baseResponse;
              
            }
            catch(Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carReprository.GetByName(name);
                if (car == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = car;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            { 
                Data = false
            };

            try
            {
                var car = await _carReprository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                await _carReprository.Delete(car);
                baseResponse.Data = true;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                { 
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel model)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Description = model.Description,
                    DateCreate = model.DateCreate,
                    Type = (TypeCar)Convert.ToInt32(model.Type),
                    Name = model.Name,
                    id = model.id,
                    Speed = model.Speed,
                    Price = model.Price
                };
                await _carReprository.Create(car);
                baseResponse.Data = model;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[CreateCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
        public async Task<IBaseResponse<Car>> EditCar(int id, CarViewModel model)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carReprository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    baseResponse.Description = "Car not found";
                    return baseResponse;
                }
                car.Description = model.Description;
                car.DateCreate = model.DateCreate;
                car.Speed = model.Speed;
                car.Price = model.Price;
                car.Name = model.Name;
                await _carReprository.Update(car);
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[EditCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
    }
}
