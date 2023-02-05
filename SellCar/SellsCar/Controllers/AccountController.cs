 using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.Identity;
using SellCar.Domain.ViewModels.Account;
namespace SellCar.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = ReturnUrl,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "No account has been created with this username before.");
                return View(model);
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    ModelState.AddModelError("", "Please confirm your membership with the link sent to your email account.");
            //    return View(model);
            //}

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            var isAdmin = _userManager.IsInRoleAsync(user, "admin");
            if (result.Succeeded)
            {
                if (isAdmin.Result)
                {
                    return Redirect("/admin");
                }
                TempData["message"] = "Signed In.";
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "Incorrect username or password entered");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                MembershipDate = DateTime.Now
            };
            var mail = await _userManager.FindByEmailAsync(model.Email);
            var username = await _userManager.FindByNameAsync(model.UserName);
            if (mail == null && username == null)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }

            }
            if (mail != null)
            {
                ModelState.AddModelError("Email", "This e-mail was previously used to register on the site.");
            }
            if (username != null)
            {
                ModelState.AddModelError("UserName", "There is another person with this username.");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["message"] = "Checked Out.";
            return Redirect("~/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}