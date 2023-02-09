
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Ads
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime DateCreate { get; set; }

        public string Description { get; set; }

        public int price { get; set; }

    }
}
