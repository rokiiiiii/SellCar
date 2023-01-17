using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Enum;
using SellCar.Domain.Helpers;
using SellCar.Domain.Models;
using SellCar.Domain.Response;
using SellCar.Domain.ViewModels.Account;
using SellCar.Service.Interfaces;
using System.Security.Claims;

namespace SellCar.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Profile> _proFileRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IBaseRepository<User> userRepository,
            ILogger<AccountService> logger, IBaseRepository<Profile> proFileRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
            _proFileRepository = proFileRepository;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "There is already a user with this login",
                    };
                }

                user = new User()
                {
                    Name = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassowrd(model.Password),
                };

                await _userRepository.Create(user);

                var profile = new Profile()
                {
                    UserId = user.Id,
                };


                await _proFileRepository.Create(profile);
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Object added",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "User not found"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassowrd(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Invalid password or login"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.UserName);
                if (user == null)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "User Not Found"
                    };
                }

                user.Password = HashPasswordHelper.HashPassowrd(model.NewPassword);
                await _userRepository.Update(user);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Password updated"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}