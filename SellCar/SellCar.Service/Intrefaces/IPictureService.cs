using SellCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Service.Intrefaces
{
    public interface IPictureService
    {

        void Create(Picture entity);
        void Update(Picture entity);
        void Delete(Picture entity);
        Picture GetById(int id);
        Picture GetByUrl(string url);
    }
}
