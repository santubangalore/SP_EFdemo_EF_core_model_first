using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_EFDemo.Models;
using System;
using System.Runtime.CompilerServices;

namespace SP_EFDemo.Repositories
{
    public class ProductService:IProductService
    {
        private readonly DbContextClass _dbContextClass;
        public ProductService(DbContextClass dbContextClass)
        {
                this._dbContextClass = dbContextClass;
        }

        /// <summary>
        /// Get Complele product list
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<List<Product>> GetProductListAsync()
        {
            return await _dbContextClass.Products.FromSqlRaw<Product>("GetProducts").ToListAsync();
        }

        /// <summary>
        /// Get prod by Id.
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int ProductId)
        {
            var param = new SqlParameter("@ProductId", ProductId);
            try
            {
                var productDetails = await
                    this._dbContextClass.Products.FromSqlRaw<Product>("exec dbo.GetProductById @ProductId", param).ToListAsync();
                return productDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Add new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>int</returns>
        public async Task<int> AddProductAsync(Product product)
        {
            var parameters= new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductName",product.ProductName));
            parameters.Add(new SqlParameter("@ProductDescription",product.ProductDescription));
            parameters.Add(new SqlParameter("@ProductPrice",product.ProductPrice));
            parameters.Add(new SqlParameter("@ProductStock",product.ProductStock));

            int value = await this._dbContextClass.Database.ExecuteSqlInterpolatedAsync($"AddNewProduct {product.ProductName}, {product.ProductDescription}, {product.ProductPrice}, {product.ProductStock}");

            return value;
        }

        /// <summary>
        /// Update Product by id 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>int</returns>
        public async Task<int> UpdateProductAsync(Product product)
        {

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", product.ProductId));
            parameters.Add(new SqlParameter("@ProductName", product.ProductName));
            parameters.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameters.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameters.Add(new SqlParameter("@ProductStock", product.ProductStock));

            var result = await Task.Run(() =>
                    _dbContextClass.Database.ExecuteSqlRawAsync("exec UpdateProduct @ProductId, @ProductName, @ProductDescription, " +
                    "@ProductPrice, @ProductStock", parameters.ToArray()));
            
            return result;
        }

        public async Task<int> DeleteProductAsync(int ProductId)
        {
         //   SqlParameter parameter = new SqlParameter("ProductId", ProductId);

            return await Task.Run(() => _dbContextClass.Database.ExecuteSqlInterpolatedAsync($"DeleteProductById {ProductId}"));
        }

        public async Task<List<ProductSales>> GetProductSalesListAsync()
        {
            var sql = FormattableStringFactory.Create("exec GetProductSalesList");

            return await this._dbContextClass.Database.SqlQuery<ProductSales>(sql).ToListAsync();

        }

        public async Task<IEnumerable<ProductSales>> GetProductSalesListByIdAsync(int ProductID)
        {
            var prodIdParam = new SqlParameter("@ProductId", ProductID);
            var sql = FormattableStringFactory.Create("exec GetProductSalesListById @ProductId",prodIdParam);

            return await this._dbContextClass.Database.SqlQuery<ProductSales>(sql).ToListAsync();
        }
    }
}
