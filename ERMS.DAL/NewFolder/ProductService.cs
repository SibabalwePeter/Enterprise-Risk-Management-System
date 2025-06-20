using ERMS.DAL.Data;
using ERMS.DL.Interfaces;
using ERMS.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMS.DAL
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;
        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            try
            {
                var products = await _dbContext.Products
                .Select(p =>
                new ProductModel
                {
                    productID = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                })
                .ToListAsync();
                return products;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }
    }
}
