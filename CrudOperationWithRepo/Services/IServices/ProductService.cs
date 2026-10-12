using System;
using System.Collections.Generic;
using CrudOperationWithRepo.Services.IServices;
using CrudOperationWithRepo.Models;

namespace CrudOperationWithRepo.Services.IServices
{
    //Here we can write all the Business logic and all the functions.

    //Encapsulation means writing all the code in single unit or class
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            //select * from products
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {   //select * from products where id=1
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
