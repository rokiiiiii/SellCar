using System.Security.Claims;
using System.Threading.Tasks;
using SellCar.Domain.ViewModels.Account;
using SellCar.Domain.Response;

namespace SellCar.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}