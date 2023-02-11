using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Ad
{
    public class AdsListViewModel
    {
        public List<Ads>? Ads { get; set; }
        public string? min_price { get; set; }
        public string? max_price { get; set; }
        public string? min_kilometers { get; set; }
        public string? max_kilometers { get; set; }
        public string? min_year { get; set; }
        public string? max_year { get; set; }
        public string[]? fuel_type { get; set; }
        public string[]? gear_type { get; set; }
        public string[]? body_type { get; set; }
        public string? min_horse { get; set; }
        public string? max_horse { get; set; }
        public string[]? traction { get; set; }
        public string[]? color { get; set; }
        public string? from_who { get; set; }
        public string? status { get; set; }
        public string? swap { get; set; }
        public string[]? region { get; set; }
    }
}
