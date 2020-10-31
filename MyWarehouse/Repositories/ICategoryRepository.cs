using MyWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWarehouse.Repositories
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        Category GetCategoryById(int id);
        List<Category> GetCategories();
    }
}
