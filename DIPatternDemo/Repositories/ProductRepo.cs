using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;
        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product prod)
        {
            int result = 0;
            db.Products.Add(prod);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProduct(Product prod)
        {
            int result = 0;
            var res=db.Products.Where(x=>x.Productid==prod.Productid).SingleOrDefault();

            if (res!=null)
            {
                db.Products.Remove(res);
                result= db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var res = (from p in db.Products
                      join c in db.Categories on p.Categoryid equals c.Categoryid
                      select new Product
                      {
                          Productid = p.Productid,
                          Productname = p.Productname,
                          Price = p.Price,
                          Categoryid = p.Categoryid,
                          Categoryname = c.Categoryname,
                          ImageUrl = p.ImageUrl
                      }).ToList();
            return res;
        }

        public Product GetProductById(int id)
        {
            // return db.Products.Where(x => x.Productid == id).SingleOrDefault();

            var res = (from p in db.Products
                      join c in db.Categories on p.Categoryid equals c.Categoryid
                      where p.Productid == id
                      select new Product
                      {
                          Productid = p.Productid,
                          Productname = p.Productname,
                          Price = p.Price,
                          Categoryid = c.Categoryid,
                          ImageUrl = p.ImageUrl,
                          Categoryname = c.Categoryname
                      }).FirstOrDefault();

            return res;

        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;
            var res = db.Products.Where(x => x.Productid == prod.Productid).SingleOrDefault();

            if (res != null)
            {
                //db.Entry(prod).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                //OR
                res.Productname = prod.Productname;
                res.Price = prod.Price;
                res.Categoryid = prod.Categoryid;
                res.ImageUrl=prod.ImageUrl;
                result = db.SaveChanges();
            }
            return result;

        }
    }
}
