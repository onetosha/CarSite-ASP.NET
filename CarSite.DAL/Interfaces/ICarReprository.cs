using CarSite.Domain.Entity;

namespace CarSite.DAL.Interfaces
{
    public interface ICarReprository : IBaseReprository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
