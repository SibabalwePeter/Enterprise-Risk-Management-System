using ERMS.core.Models;

namespace ERMS.core.Models.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductModel>> GetProducts();
    }
}
