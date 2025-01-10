using SP_EFDemo.Models;

namespace SP_EFDemo.Repositories
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<IEnumerable<Product>> GetProductByIdAsync(int ProductId);
        public Task<int> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int ProductId);

        public Task<List<ProductSales>> GetProductSalesListAsync();
        public Task<IEnumerable<ProductSales>> GetProductSalesListByIdAsync(int ProductId);

    }
}
