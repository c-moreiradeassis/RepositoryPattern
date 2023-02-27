namespace Domain.RepositoryInterfaces
{
    public interface DatabaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        void Remove(int id);
        void Update(TEntity entity);
    }
}
