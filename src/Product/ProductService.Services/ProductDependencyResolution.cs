using Ninject.Modules;
using ProductService.Domain.Interfaces;
using ProductService.Instrastructure.Data.Repository;
using ProductService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductDependencyResolution : NinjectModule
    {
        public override void Load()
        {
            Bind<ProductContext>().ToSelf();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IProductService>().To<ProductService.Services.Implementation.ProductService>();
        }
    }
}
