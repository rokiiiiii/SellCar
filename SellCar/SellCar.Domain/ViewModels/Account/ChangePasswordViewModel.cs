using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Enter login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "Password must be greater than or equal to 5 characters")]
        public string NewPassword { get; set; }
    }
}