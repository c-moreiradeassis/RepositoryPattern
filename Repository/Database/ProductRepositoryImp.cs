using Domain.Models.Database;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Database.Context;

namespace Repository.Database
{
    public class ProductRepositoryImp : DatabaseRepositoryImp<Product>, ProductRepository
    {
        private DbSet<Product> _dbSet;

        public ProductRepositoryImp(DataContext context) : base(context)
        {
            _dbSet = context.Set<Product>();
        }
    }
}
