
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public List<Ads> Ads { get; set; }

    }
}
