using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Profile;

namespace SellCar.Service.Intrefaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);

        Task<BaseResponse<Profile>> Save(ProfileViewModel model);
    }
}
