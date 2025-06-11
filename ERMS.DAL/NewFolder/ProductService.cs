using ERMS.core.Models;
using ERMS.DAL.Data;

namespace ERMS.DAL
{
    public class ProductService
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
                var users = _dbContext.Products
                .Select(p =>
                new ProductModel
                {
                    productID = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                })
                .ToList();
                return users;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }
    }
}
