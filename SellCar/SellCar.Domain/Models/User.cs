using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateRegistration { get; set; }

    }
}
