using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface ICategoryRepo
    {

        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);

    }
}
