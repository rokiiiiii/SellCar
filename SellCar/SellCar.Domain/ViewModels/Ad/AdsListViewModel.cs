using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Ad
{
    public class AdsListViewModel
    {
        public List<Ads>? Ads { get; set; }
        public string? minPrice { get; set; }
        public string? maxPrice { get; set; }
        public string? minMileage { get; set; }
        public string? maxMileage { get; set; }
        public string? minYear { get; set; }
        public string? maxYear { get; set; }
        public string[]? fuelType { get; set; }
        public string[]? gearType { get; set; }
        public string[]? bodyType { get; set; }
        public string? minHorse { get; set; }
        public string? maxHorse { get; set; }
        public string[]? TractionType { get; set; }
        public string[]? Color { get; set; }
        public string? FromWho { get; set; }
        public string? Status { get; set; }
        public string? Swap { get; set; }
        public string[]? Region { get; set; }

    }
}
