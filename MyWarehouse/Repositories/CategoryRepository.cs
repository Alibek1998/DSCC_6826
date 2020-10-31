using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWarehouse.DbContexts;
using MyWarehouse.Model;

namespace MyWarehouse.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ProductContext db;

        public CategoryRepository(ProductContext productContext)
        {
            db = productContext;
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategoryById(id);
            db.Entry(category).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }


        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }


        //List<Category> ICategoryRepository.GetCategories()
        //{
        //    throw new NotImplementedException();
        //}

        //Category ICategoryRepository.GetCategoryById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
