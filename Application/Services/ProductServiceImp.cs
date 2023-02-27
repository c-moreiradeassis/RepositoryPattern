using Application.ServicesIntefaces;
using Domain.Models.Database;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class ProductServiceImp : ProductService
    {
        private ProductRepository _repository;
        private DapperRepository _dapperRepository;

        public ProductServiceImp(ProductRepository repository, DapperRepository dapperRepository)
        {
            _repository = repository;
            _dapperRepository = dapperRepository;
        }

        public void Add(Product product)
        {
            _repository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(Product product)
        {
            _repository.Update(product);
        }

        public void AddDapper(Product product)
        {
            _dapperRepository.Add(product);
        }

        public List<Product> GetAllDapper()
        {
            return _dapperRepository.GetAll();
        }

        public Product GetByIdDapper(int id)
        {
            return _dapperRepository.GetById(id);
        }

        public void RemoveDapper(int id)
        {
            _dapperRepository.Remove(id);
        }

        public void UpdateDapper(Product product)
        {
            _dapperRepository.Update(product);
        }
    }
}
