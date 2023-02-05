using SellCar.Domain.Identity;
using SellCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.ViewModels.Users
{
    public class UserAdsListViewModel
    {
        public List<Ads> Ads { get; set; }
        public User User { get; set; }
    }
}
