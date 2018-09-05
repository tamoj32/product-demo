using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Instrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            _dbContext.Products.Remove(_dbContext.Products.Single(p => p.Id == id));
            _dbContext.SaveChanges();
        }

        public Product Get(string id)
        {
            return _dbContext.Products.Single(p => p.Id == id);
        }

        public IEnumerable<Product> GetByParam(string description, string model, string brand)
        {
            return _dbContext.Products.Where(p => p.Description == description && p.Model == model && p.Brand == brand);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = (from c in _dbContext.Products select c);
            return products;
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }
    }
}
