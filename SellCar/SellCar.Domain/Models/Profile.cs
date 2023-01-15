using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
