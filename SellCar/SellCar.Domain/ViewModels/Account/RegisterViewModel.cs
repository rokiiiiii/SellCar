using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The name field cannot be left blank.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surname field cannot be left blank.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username field cannot be left blank.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Re-enter your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Email field cannot be left blank.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address field cannot be left blank.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone field cannot be left blank.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}