using SellCar.Domain.Models;

namespace SellCar.Service.Intrefaces
{
    public interface ICarService
    {

        void Create(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        Car GetById(int id);
        List<Car> GetCars();
        Car GetByIdWithPosts(int markaId);


    }
}
