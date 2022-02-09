using TiendasSI.Web.Models;

namespace TiendasSI.Web.IServices
{
    public interface IProductionsServices
    {
        Task<Production> DeleteProductionAsync(int id);
        Task<Production> EditProductionAsync(Production production);
        Task<Production> GetProductionAsync(int id);
        Task<List<Production>> GetProductionsAsync();
    }
}
