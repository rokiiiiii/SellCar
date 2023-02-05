using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
