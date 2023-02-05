using Microsoft.AspNet.Http;
using SellCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.ViewModels.Ad
{
    public class EditAdsViewModel
    {
        public int AdsId { get; set; }
        [Required(ErrorMessage = "Ad Title cannot be left blank.")]
        public string Title { get; set; }
        public string Detail { get; set; }
        [Required(ErrorMessage = "Indicate the city where your vehicle is located.")]
        public string RegionId { get; set; }
        [Required(ErrorMessage = "Specify the brand of your vehicle.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Specify the model of your vehicle.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please indicate how many models your vehicle has.")]
        [Range(1950, 2023,
        ErrorMessage = "The year must be between 1950 and 2023")]
        public int year { get; set; }
        [Required(ErrorMessage = "Select the fuel type of your vehicle.")]
        public string FuelType { get; set; }
        [Required(ErrorMessage = "Select the gear type of your vehicle.")]
        public string GearType { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int NumberOfGears { get; set; }
        [Required(ErrorMessage = "Specify the mileage of your vehicle.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Select the body type of your vehicle.")]
        public string BodyType { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int NumberOfDoors { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        [Required(ErrorMessage = "Specify the engine power of your vehicle.")]
        public int MotorPower { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int EngineCapacity { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int MaxSpeed { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public double Acceleration { get; set; }
        [Required(ErrorMessage = "Select your vehicle's traction type.")]
        public string TractionType { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public double InnerCityConsumption { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public double OutOfCityConsumption { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public double AverageConsumption { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]
        public int FuelTankVolume { get; set; }
        [Required(ErrorMessage = "Choose the color of your vehicle")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Select who sold your vehicle to.")]
        public string FromWho { get; set; }
        [Required(ErrorMessage = "Select whether the vehicle is open to trade or not.")]
        public string Swap { get; set; }
        [Required(ErrorMessage = "Select the condition of your vehicle.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Specify the price at which you want to sell your vehicle.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "You cannot enter a negative value.")]

        public double Price { get; set; }
        [Required(ErrorMessage = "Select the brand of your vehicle.")]
        public string CarId { get; set; }

        public bool HomePage { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<Picture> PostingPictures { get; set; }
    }
}
