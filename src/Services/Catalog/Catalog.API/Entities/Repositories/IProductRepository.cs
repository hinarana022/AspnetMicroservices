using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Entities.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string Id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string category);
        Task CreateProduct(Product product);
        Task<bool> updateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
