
using System.ComponentModel.DataAnnotations;

namespace SellsCar.DbModels
{
    public class Ads
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime DateCreate { get; set; }
      
    }
}
