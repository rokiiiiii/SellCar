using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Regions
{
    public class RegionViewModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
