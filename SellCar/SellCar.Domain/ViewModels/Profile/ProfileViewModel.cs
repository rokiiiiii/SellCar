using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
}
