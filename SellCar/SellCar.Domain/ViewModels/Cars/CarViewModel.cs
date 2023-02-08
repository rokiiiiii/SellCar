using SellCar.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.Cars
{
    public class CarViewModel
    {
        [Required]
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
