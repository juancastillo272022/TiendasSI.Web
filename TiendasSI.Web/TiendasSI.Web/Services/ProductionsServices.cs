using Newtonsoft.Json;
using TiendasSI.Web.IServices;
using TiendasSI.Web.Models;

namespace TiendasSI.Web.Services
{
    public class ProductionsServices : IProductionsServices
    {
        public Task<Production> DeleteProductionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Production> EditProductionAsync(Production production)
        {
            throw new NotImplementedException();
        }

        public Task<Production> GetProductionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Production>> GetProductionsAsync()
        {
            HttpClient client = new HttpClient();
            List<Production> productions = new List<Production>();
            var json = await client.GetStringAsync("https://localhost:7133/api/Production");
            if (json != null)
            {
                productions = JsonConvert.DeserializeObject<List<Production>>(json);
            }
            return productions;
        }
    }
}
