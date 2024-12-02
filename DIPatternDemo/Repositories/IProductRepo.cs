using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        int AddProduct(Product prod);

        int UpdateProduct(Product prod);

        int DeleteProduct(Product prod);
    }
}
