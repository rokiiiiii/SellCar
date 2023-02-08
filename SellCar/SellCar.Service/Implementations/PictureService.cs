using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class PictureService : IPictureService
    {
        private IPictureRepository _picRepository;

        public PictureService(IPictureRepository picRepository)
        {
            _picRepository = picRepository;
        }

        public void Create(Picture entity)
        {
            _picRepository.Create(entity);
        }
        public void Update(Picture entity)
        {
            _picRepository.Update(entity);
        }
        public void Delete(Picture entity)
        {
            _picRepository.Delete(entity);
        }
        public Picture GetById(int id)
        {
            return _picRepository.GetById(id);
        }
        public Picture GetByUrl(string url)
        {
            return _picRepository.GetByUrl(url);
        }
    }
}