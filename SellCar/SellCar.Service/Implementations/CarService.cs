using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.DAL.Repositories;
using SellCar.Domain.Enum;
using SellCar.Domain.Extensions;
using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Car;
using SellCar.Domain.ViewModels.User;
using SellCar.Service.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Service.Implementations
{
    public class CarService:ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<CarViewModel>> GetCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "User not Found",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new CarViewModel()
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    YearCreate = car.YearCreate.ToLongDateString(),
                    TypeCar = car.TypeCar.GetDisplayName(),
                    HoursPower = car.HoursPower,
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Dictionary<int, string>>> GetCar(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<int, string>>();
            try
            {
                var cars = await _carRepository.GetAll()
                    .Select(x => new CarViewModel()
                    {
                        Id = x.Id,
                        Brand = x.Brand,
                        Model = x.Model,
                        YearCreate = x.YearCreate.ToLongDateString(),
                        TypeCar = x.TypeCar.GetDisplayName(),
                        HoursPower = x.HoursPower,
                    })
                    .Where(x => EF.Functions.Like(x.Brand,$"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Brand);

                baseResponse.Data = cars;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Car>> Create(CarViewModel model, byte[] imageData)
        {
            try
            {
                var car = new Car()
                {

                    Brand = model.Brand,
                    Model = model.Model,
                    YearCreate = DateTime.Now,
                    HoursPower = model.HoursPower,
                    TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
                
                };
                await _carRepository.Create(car);

                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }

                car.Brand = model.Brand;
                car.Model = model.Model;
                car.YearCreate = DateTime.ParseExact(model.YearCreate, "yyyyMMdd HH:mm", null);
                car.HoursPower = model.HoursPower;

                await _carRepository.Update(car);


                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Description = "Found 0 items",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
