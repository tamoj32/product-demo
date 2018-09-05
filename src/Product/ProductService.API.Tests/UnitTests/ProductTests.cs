using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Instrastructure.Data.Repository;

namespace ProductService.API.Tests.UnitTests
{
    [TestClass]
    public class ProductTests
    {
        private IProductRepository repo;
        private readonly DbContextOptions<ProductContext> options;

        public ProductTests()
        {
            options = new DbContextOptionsBuilder<ProductContext>()
                            .UseInMemoryDatabase("Product.InMemoryTest")
                            .Options;
        }

        [TestMethod]
        public void RepoAndControllerTests()
        {

            // Run the test against one instance of the context
            using (var context = new ProductContext(options))
            {
                repo = new ProductRepository(context);

                Add_Repo_Database();

                GetAll_Repo_Database();

                GetAll_Controller();

                Get_Repo_Database();

                Update_Repo_Database();

                Delete_Repo_Database();
            }
        }
                
        private void Add_Repo_Database()
        {
            repo.Add(new Product { Id = "1", Description = "Product 1", Brand = "Brand 1", Model = "Model 1" });

            using (var context = new ProductContext(options))
            {
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual("Product 1", context.Products.Single().Description);
            }
        }

        
        private void GetAll_Repo_Database()
        {
            
            var products = repo.GetAll();

            using (var context = new ProductContext(options))
            {
                Assert.AreEqual(products.Count(), context.Products.Count());
            }
        }

        
        private void Get_Repo_Database()
        {
            var product = repo.Get("1");
            using (var context = new ProductContext(options))
            {
                Assert.AreEqual("Product 1", context.Products.Single(p=> p.Id == "1").Description);
            }
        }

        
        private void Update_Repo_Database()
        {
            var product = repo.Get("1");
            product.Description = "Product 1 Updated";
            repo.Update(product);

            using (var context = new ProductContext(options))
            {
                Assert.AreEqual("Product 1 Updated", context.Products.Single(p => p.Id == "1").Description);
            }
        }

        private void Delete_Repo_Database()
        {
            repo.Delete("1");
            using (var context = new ProductContext(options))
            {
                Assert.AreEqual(0, context.Products.Count());
            }
        }


        private void GetAll_Controller()
        {
            //var controller = _ninjectKernel.Get<Controllers.ProductController>();

            var controller = new Controllers.ProductController(repo);

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase("Product.InMemory")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ProductContext(options))
            {
                var repo = new ProductRepository(context);
                repo.Add(new Product { Id = "1", Description = "Product 1", Brand = "Brand 1", Model = "Model 1" });
            };

            // Act
            var result = controller.Get();

            // Assert
            Assert.AreEqual(result.Count(), 1);

        }
    }
}
