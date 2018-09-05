using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ProductService.API.helper;

namespace ProductService.API.Controllers
{
    [RoutePrefix("api/product")]
    [ClaimsAuthorization(ClaimType = "permission", ClaimValue = "administrator")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        // GET: api/Product/5
        public Product Get(string id)
        {
            return _productRepository.Get(id);
        }

        [Route("{description}/{model}/{brand}")]
        public IEnumerable<Product> Get(string description, string model, string brand)
        {
            return _productRepository.GetByParam(description, model, brand);
        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            _productRepository.Add(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            _productRepository.Update(product);
        }

        // DELETE: api/Product/5
        public void Delete(string id)
        {
            _productRepository.Delete(id);
        }
    }
}
