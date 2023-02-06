using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int AdsId { get; set; }
        public Ads Ads { get; set; }
    }
}
