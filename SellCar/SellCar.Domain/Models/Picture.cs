using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public int AdsId { get; set; }
        public Ads Ads { get; set; }
    }
}
