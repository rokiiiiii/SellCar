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

        public Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel userViewModel);
        public Task<IBaseResponse<User>> Edit(int id,UserViewModel model);
        public  Task<IBaseResponse<bool>> DeleteUser(int id);
        public Task<IBaseResponse<User>> GetByName(string name);
        public Task<IBaseResponse<IEnumerable<User>>> GetUsers();
        public Task<IBaseResponse<User>> GetUser(int id);


    }
}
