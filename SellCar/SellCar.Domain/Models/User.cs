using SellCar.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SellCar.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }

        public Profile Profile { get; set; }



    }

  
}
