using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.User
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Specify role")]
        [Display(Name = "Rolke")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Enter your login")]
        [Display(Name = "Login")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
