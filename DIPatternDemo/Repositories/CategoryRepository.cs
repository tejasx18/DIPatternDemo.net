using Azure;
using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCategory(Category category)
        {
            int result =0;
            db.Categories.Add(category);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            Category response = db.Categories.Where(x=>x.CategoryID==id).SingleOrDefault();
            if (response != null)
            {
                db.Categories.Remove(response);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x => x.CategoryID == id).SingleOrDefault();
        }

        public int UpdateCategory(Category category)
        {
            int result = 0;
            Category response = db.Categories.Where(x => x.CategoryID == category.CategoryID).SingleOrDefault();
            if (response != null)
            {
                response.CategoryName=category.CategoryName;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
