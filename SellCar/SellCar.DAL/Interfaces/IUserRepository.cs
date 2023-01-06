using SellCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByName(string name);
    }
}
