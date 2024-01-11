using Microsoft.EntityFrameworkCore;
using WebApplicationLar.Context;
using WebApplicationLar.Entities;

namespace WebApplicationLar.Services
{
    public class CarServices : ICarServices
    {
        private readonly ApplicationDbContext _context;

        public CarServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetById(Guid Id)
        {
            return await _context.Cars.FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
