﻿using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product Get(string id);

        IEnumerable<Product> GetByParam(string description, string model, string brand);

        void Add(Product product);

        void Update(Product product);

        void Delete(string id);
    }
}
