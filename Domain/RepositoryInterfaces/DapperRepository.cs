using Domain.Models.Database;

namespace Domain.RepositoryInterfaces
{
    public interface DapperRepository
    {
        void Add(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        void Remove(int id);
        void Update(Product product);
    }
}
