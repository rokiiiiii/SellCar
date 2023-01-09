using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound=0,
        CarNotFound=1,
        OK=200,
        InternalServerError=500
    }
}
