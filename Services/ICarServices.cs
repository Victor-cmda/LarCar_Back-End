using WebApplicationLar.Entities;

namespace WebApplicationLar.Services
{
    public interface ICarServices
    {
        Task<Car> GetById(Guid Id);
        Task<IEnumerable<Car>> GetAll();
        Task Add(Car car);
        Task Update(Car car);
        Task Delete(Guid id);
    }
}
