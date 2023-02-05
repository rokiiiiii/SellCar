using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        List<Car> GetCars();
        Car GetByIdWithPosts(int markaId);

    }
}
