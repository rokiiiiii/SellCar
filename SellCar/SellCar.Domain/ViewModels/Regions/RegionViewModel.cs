using SellCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.ViewModels.Regions
{
    public class RegionViewModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
