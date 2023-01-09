using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Car;
using SellCar.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Service.Intrefaces
{
    public interface ICarService
    {

        public Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
        public Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
        public Task<IBaseResponse<bool>> DeleteCar(int id);
        public Task<IBaseResponse<Car>> GetByModel(string name);
        public Task<IBaseResponse<IEnumerable<Car>>> GetCars();
        public Task<IBaseResponse<Car>> GetCar(int id);


    }
}
