using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Ad
{
    public class AdsListViewModel
    {
        public List<Ads>? Ads { get; set; }
        public string? MinPrice { get; set; }
        public string? MaxPrice { get; set; }
        public string? MinMileage { get; set; }
        public string? MaxMileage { get; set; }
        public string? MinYear{ get; set; }
        public string? MaxYear { get; set; }
        public string[]? FuelType { get; set; }
        public string[]? GearType { get; set; }
        public string[]? BodyType { get; set; }
        public string? MinHorse { get; set; }
        public string? MaxHorse { get; set; }
        public string[]? Traction { get; set; }
        public string[]? Color { get; set; }
        public string? FromWho { get; set; }
        public string? Status { get; set; }
        public string? Swap { get; set; }
        public string[]? Region { get; set; }
    }
}
