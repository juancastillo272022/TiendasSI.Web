using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TiendasSI.Web.Models;

namespace TiendasSI.Web.Controllers
{
    public class ProductionsControllers : Controller
    {
        // GET: ProductionsControllers
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:7133/api/Production");
            var productionsList = JsonConvert.DeserializeObject<List<Production>>(json);
            return View(productionsList);
        }

        // GET: ProductionsControllers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:7133/api/Production/{id}");
            var production = JsonConvert.DeserializeObject<Production>(json);
            return View(production);
        }

        // GET: ProductionsControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionsControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Title,ReleaseDate,Producer,Type,Value")] Production production)
        {
            try
            {
                var client = new HttpClient();
                var json = await client.PostAsJsonAsync("https://localhost:7133/api/Production", production);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductionsControllers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:7133/api/Production/{id}");
            var production = JsonConvert.DeserializeObject<Production>(json);
            return View(production);
        }

        // POST: ProductionsControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("IdProduction,Title,ReleaseDate,Producer,Type,Value,Status")] Production production)
        {
            try
            {
                var client = new HttpClient();
                production.IdProduction = id;
                var json = await client.PutAsJsonAsync($"https://localhost:7133/api/Production/{id}", production);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductionsControllers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:7133/api/Production/{id}");
            var production = JsonConvert.DeserializeObject<Production>(json);
            return View(production);
        }

        // POST: ProductionsControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.DeleteAsync($"https://localhost:7133/api/Production/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
