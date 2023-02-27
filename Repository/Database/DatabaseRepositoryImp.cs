using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Database.Context;

namespace Repository.Database
{
    public class DatabaseRepositoryImp<TEntity> : DatabaseRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private DataContext _context;

        public DatabaseRepositoryImp(DataContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);

            _context.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            TEntity obj = _dbSet.Find(id);

            _dbSet.Remove(obj);

            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);

            _context.SaveChanges();
        }
    }
}
