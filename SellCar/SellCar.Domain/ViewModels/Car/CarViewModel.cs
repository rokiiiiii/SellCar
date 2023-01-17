using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Enter Brand")]
        [MinLength(2, ErrorMessage = "Minimum length must be greater than 2 characters")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Enter Model")]
        [MinLength(2, ErrorMessage = "Minimum length must be greater than 2 characters")]
        public string Model { get; set; }

        public string YearCreate { get; set; }

        [Display(Name = "Type car")]
        [Required(ErrorMessage = "Select type")]
        public string TypeCar { get; set; }
        public int HoursPower { get; set; }
    }
}
