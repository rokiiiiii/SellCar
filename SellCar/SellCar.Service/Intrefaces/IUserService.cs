using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Service.Intrefaces
{
    public interface IUserService
    {

        Task<IBaseResponse<User>> Create(UserViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);

    }
}
