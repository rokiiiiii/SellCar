
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.Models
{
    public class Ads
    {
        [Key]
        public int AdsId { get; set; }
        public string title { get; set; }
        public string Detail { get; set; }
        public DateTime DateCreate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int year { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public int NumberOfGear { get; set; }
        public int Mileage { get; set; }
        public string BodyType { get; set; }
        public int NumberOfDoors { get; set; }
        public int MotorPower { get; set; }
        public int EngineСapacity { get; set; }
        public int MaxSpeed { get; set; }
        public double Acceleration { get; set; }
        public string TractionType { get; set; }
        public double ConsumptionСity { get; set; }
        public double OutofCityConsumption { get; set; }
        public double AverageConsumption { get; set; }
        public int FuelTankVolume { get; set; }
        public string Color { get; set; }
        public string FromWho { get; set; }
        public string Swap { get; set; }
        public string Status { get; set; }
        public bool HomePage { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<Picture> PostingPictures { get; set; }

    }
}
