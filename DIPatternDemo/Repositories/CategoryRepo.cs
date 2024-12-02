using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext db;
        public CategoryRepo(ApplicationDbContext db)
        {
            this.db = db;  
        }
        public int AddCategory(Category cat)
        {
            int result = 0;
            db.Categories?.Add(cat);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            var res=db.Categories?.Where(x=>x.Categoryid==id).SingleOrDefault();

            if(res != null)
            {
                db.Categories?.Remove(res);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories?.Where(x => x.Categoryid == id).SingleOrDefault();
        }

        public int UpdateCategory(Category cat)
        {
            int result = 0;
            var res=db.Categories?.Where(x=>x.Categoryid==cat.Categoryid).SingleOrDefault();
            if(res != null)
            {
                res.Categoryname = cat.Categoryname;
                result= db.SaveChanges();
            }
            return result;
        }
    }
}
