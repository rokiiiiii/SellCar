using SellCar.Domain.Models;

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
