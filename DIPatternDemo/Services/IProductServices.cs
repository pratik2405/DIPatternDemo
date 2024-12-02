using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        int AddProduct(Product prod);

        int UpdateProduct(Product prod);

        int DeleteProduct(Product prod);
    }
}
