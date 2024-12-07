﻿using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int id);

        int AddProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProduct(int id);
    }
}
