using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            Product response = db.Products.Where(x=>x.ProductId==id).SingleOrDefault();
            if (response != null)
            {
                db.Products.Remove(response);
                result = db.SaveChanges();
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            //return db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            var result = (from p in db.Products
                         join c in db.Categories on p.CategoryId equals c.CategoryID
                         where p.ProductId == id
                         select new Product
                         {
                             ProductId = p.ProductId,
                             CategoryId = p.CategoryId,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             ImageUrl = p.ImageUrl,
                             Price = p.Price,
                         }).SingleOrDefault();
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            var result = (from p in db.Products
                         join c in db.Categories on p.CategoryId equals c.CategoryID
                         select new Product
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             Price = p.Price,
                             CategoryName = c.CategoryName,
                             CategoryId = p.CategoryId,
                             ImageUrl = p.ImageUrl,
                         }).ToList();
            return result;

        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            Product response = db.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault();
            if (response != null)
            {
                response.ProductName=product.ProductName;
                response.Price=product.Price;
                response.CategoryId=product.CategoryId;
                response.ImageUrl=product.ImageUrl;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
