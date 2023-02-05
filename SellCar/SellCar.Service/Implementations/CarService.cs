using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class CarService : ICarService
    {
        private ICarRepository _CarRepository;

        public CarService(ICarRepository carRepository)
        {
            _CarRepository = carRepository;
        }

        public void Create(Car entity)
        {
            _CarRepository.Create(entity);
        }
        public void Update(Car entity)
        {
            _CarRepository.Update(entity);
        }
        public void Delete(Car entity)
        {
            _CarRepository.Delete(entity);
        }
        public Car GetById(int id)
        {
            return _CarRepository.GetById(id);
        }
        public Car GetByIdWithPosts(int markaId)
        {
            return _CarRepository.GetByIdWithPosts(markaId);
        }
        public List<Car> GetCars()
        {
            return _CarRepository.GetCars();
        }

    }
}
