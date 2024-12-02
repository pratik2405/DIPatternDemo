using DIPatternDemo.Models;
using DIPatternDemo.Repositories;

namespace DIPatternDemo.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepo Repo;
        public ProductServices(IProductRepo Repo)
        {
            this.Repo = Repo;
        }
        public int AddProduct(Product prod)
        {
           return Repo.AddProduct(prod);
        }

        public int DeleteProduct(Product prod)
        {
            return Repo.DeleteProduct(prod);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return Repo.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return Repo.GetProductById(id);
        }

        public int UpdateProduct(Product prod)
        {
            return Repo.UpdateProduct(prod);
        }
    }
}
