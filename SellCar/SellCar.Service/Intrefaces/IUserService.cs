using SellCar.Domain.Models;
using SellCar.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Service.Intrefaces
{
    public class IUserService
    {
        public Task<IBaseResponse<IEnumerable<User>>> GetUsers();
       
    }
}
