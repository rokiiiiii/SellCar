using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;

namespace SellCar.DAL.Repositories
{
    public class GenericRepository<TEntity, TContext> : IBaseRepository<TEntity>
     where TEntity : class
     where TContext : DbContext, new()
    {

        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified; ;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }

        }
    }
}
