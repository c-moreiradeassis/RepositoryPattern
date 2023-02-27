using Domain.Models.Database;

namespace Application.ServicesIntefaces
{
    public interface ProductService
    {
        void Add(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        void Remove(int id);
        void Update(Product product);
        void AddDapper(Product product);
        List<Product> GetAllDapper();
        Product GetByIdDapper(int id);
        void RemoveDapper(int id);
        void UpdateDapper(Product product);
    }
}
