using System.ComponentModel.DataAnnotations;

namespace SellsCar.DbModels
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YeCreate { get; set; }
        public string Type { get; set; }
    }
}
