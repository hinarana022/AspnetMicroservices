using Catalog.API.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog.API.Entities.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext context;

        public ProductRepository(ICatalogContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await context.Products.Find(p => p.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable< Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await context.Products.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByCategory(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, name);
            return await context.Products.Find(filter).ToListAsync();
        }
        public async Task CreateProduct(Product product)
        {
            await context.Products.InsertOneAsync(product);
        }
        public async Task<bool> updateProduct(Product product)
        {
            var resultupdate=await context.Products.ReplaceOneAsync(filter: g=>g.Id==product.Id,replacement:product);
            return resultupdate.IsAcknowledged && resultupdate.ModifiedCount > 0;
        }
        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var resultupdate = await context.Products.DeleteOneAsync(filter);
            return resultupdate.IsAcknowledged && resultupdate.DeletedCount > 0;
        }
    }
}
