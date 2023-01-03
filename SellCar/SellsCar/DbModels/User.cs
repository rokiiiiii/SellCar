using System.ComponentModel.DataAnnotations;

namespace SellsCar.DbModels
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Namee { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateRegistr { get; set; }

    }
}
