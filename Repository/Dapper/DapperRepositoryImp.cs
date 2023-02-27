using Dapper;
using Domain.Models.Database;
using Domain.RepositoryInterfaces;
using Microsoft.Data.Sqlite;

namespace Repository.Dapper
{
    public class DapperRepositoryImp : DapperRepository
    {
        private string _connectionString;

        public DapperRepositoryImp(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            var command = @"INSERT INTO Product (
                                        Id,
                                        Description,
                                        Value,
                                        CreateAt)    
                                 SELECT @Id,
                                        @Description,
                                        @Value,
                                        @CreateAt";

            using (var sqlConnection = new SqliteConnection(_connectionString))
            {
                sqlConnection.Execute(command, new
                {
                    Id = product.Id,
                    Description = product.Description,
                    Value = product.Value,
                    CreateAt = DateTime.Now
                });
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            var query = @"SELECT Id, Description, Value, CreateAt FROM Product";

            using (var sqlConnection = new SqliteConnection(_connectionString))
            {
                products = sqlConnection.Query<Product>(query).ToList();
            }

            return products;
        }

        public Product GetById(int id)
        {
            Product product = new Product();

            var query = @"SELECT Id, Description, Value, CreateAt FROM Product WHERE Id = @Id";

            using (var sqlConnection = new SqliteConnection(_connectionString))
            {
                product = sqlConnection.Query<Product>(query, new { Id = id }).FirstOrDefault();
            }

            return product;
        }

        public void Remove(int id)
        {
            var command = @"DELETE FROM Product WHERE Id = @Id";

            using (var sqlConnection = new SqliteConnection(_connectionString))
            {
                sqlConnection.Execute(command, new { Id = id });
            }
        }

        public void Update(Product product)
        {
            var command = @"UPDATE Product
                               SET Description = @Description, 
                                   Value = @Value, 
                                   CreateAt = @CreateAt
                             WHERE Id = @Id";

            using (var sqlConnection = new SqliteConnection(_connectionString))
            {
                sqlConnection.Execute(command, new
                {
                    Id = product.Id,
                    Description = product.Description,
                    Value = product.Value,
                    CreateAt = product.CreateAt
                });
            }
        }
    }
}
