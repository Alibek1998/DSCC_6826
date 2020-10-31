using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWarehouse.DbContexts;
using MyWarehouse.Model;

namespace MyWarehouse.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext db;

        public ProductRepository(ProductContext productContext)
        {
            db = productContext;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return db.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }


        public void UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }


        //Product IProductRepository.GetProductById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //List<Product> IProductRepository.GetProducts()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
