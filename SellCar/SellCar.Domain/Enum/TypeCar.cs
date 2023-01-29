using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Saloon")]
        Saloon = 0,
        [Display(Name = "Hatchback")]
        Hatchback = 1,
        [Display(Name = "Estate")]
        Estate = 2,
        [Display(Name = "Coupe")]
        Coupe = 3,
        [Display(Name = "Sport Utility Vehicle")]
        SUV = 4,
        [Display(Name = "Crossover Utility Vehicle")]
        CUV = 5

    }
}
