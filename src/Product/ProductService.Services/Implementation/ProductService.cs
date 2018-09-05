using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(string id)
        {
            _productRepository.Delete(id);
        }

        public Product Get(string id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetByParam(string description, string model, string brand)
        {
            return _productRepository.GetByParam(description, model, brand);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
