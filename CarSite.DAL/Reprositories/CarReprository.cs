using System.Collections.Generic;
using System.Threading.Tasks;
using CarSite.DAL.Interfaces;
using CarSite.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarSite.DAL.Reprositories
{
    public class CarReprository : ICarReprository
    {
        private readonly ApplicationDbContext _db;
        public CarReprository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await _db.Car.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _db.Car.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _db.Car.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Car>> Select()
        {
            return await _db.Car.ToListAsync();
        }
        public async Task<Car> Update(Car entity)
        {
            _db.Car.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
