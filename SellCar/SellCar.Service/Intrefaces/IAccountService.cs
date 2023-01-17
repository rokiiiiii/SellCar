using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Account;
using System.Security.Claims;

namespace SellCar.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}