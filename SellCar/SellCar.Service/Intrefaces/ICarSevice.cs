using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Car;

namespace SellCar.Service.Intrefaces
{
    public interface ICarService
    {

        BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Car>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(long id);

        Task<BaseResponse<Dictionary<int, string>>> GetCar(string term);

        Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteCar(long id);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);


    }
}
