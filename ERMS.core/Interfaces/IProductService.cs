using ERMS.DL.Models;

namespace ERMS.DL.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductModel>> GetProducts();
    }
}
