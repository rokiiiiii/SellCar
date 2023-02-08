using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface IPictureRepository : IBaseRepository<Picture>
    {
        Picture GetByUrl(string url);
    }
}
