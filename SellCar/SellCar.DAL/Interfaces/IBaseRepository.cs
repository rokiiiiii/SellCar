namespace SellCar.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
