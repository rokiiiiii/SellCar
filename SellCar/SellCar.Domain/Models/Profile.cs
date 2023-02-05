using SellCar.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Profile
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
    }
}
