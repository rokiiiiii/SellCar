using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);

        T Get(int id);

        IEnumerable<T> Select();
        bool Delete(T entity);  
    }
}
