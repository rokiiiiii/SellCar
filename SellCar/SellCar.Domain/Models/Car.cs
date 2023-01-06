using SellCar.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearCreate { get; set; }
        public TypeCar TypeCar { get; set; }
        public int HoursPower { get; set; } 
    }
}
