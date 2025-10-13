using CurrentDocument.Shared.Enums;
using CurrentService.WEBUI.Models;
using CurrentService.WEBUI.Services.DocumentStrategies;
using Document.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;

namespace CurrentService.WEBUI.Controllers
{
    public class CariController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DocumentStrategy _strategyFactory;

        public CariController(IHttpClientFactory httpClientFactory, DocumentStrategy strategyFactory)
        {
            _httpClientFactory = httpClientFactory;
            _strategyFactory = strategyFactory;
        }

        private HttpClient CreateApiClient(string? firmaInd)
        {
            firmaInd ??= "101";
            string xFirmaInd = firmaInd;

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7227/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", xFirmaInd);
            return client;
        }

        private HttpClient CreateApiClientWithDonem(string? firmaInd, string? donemInd = null)
        {
            var client = CreateApiClient(firmaInd);

            donemInd ??= "0003";
            client.DefaultRequestHeaders.Remove("X-DonemInd");
            client.DefaultRequestHeaders.Add("X-DonemInd", donemInd);
            return client;
        }

        private HttpClient CreateFaturaApiClient(string? firmaInd)
        {
            firmaInd ??= "101";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7059/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);
            return client;
        }

        private HttpClient CreateFaturaApiClientWithDonem(string? firmaInd, string? donemInd = null)
        {
            var client = CreateFaturaApiClient(firmaInd);
            donemInd ??= "0003";
            client.DefaultRequestHeaders.Remove("X-DonemInd");
            client.DefaultRequestHeaders.Add("X-DonemInd", donemInd);
            return client;
        }

        private HttpClient CreateCariFaturaApiClient(string? firmaInd)       //CarGir-CarCik
        {
            firmaInd ??= "101";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);
            return client;
        }

        private HttpClient CreateCariFaturaApiClientWithDonem(string? firmaInd, string? donemInd = null)
        {
            var client = CreateFaturaApiClient(firmaInd);
            donemInd ??= "0003";
            client.DefaultRequestHeaders.Remove("X-DonemInd");
            client.DefaultRequestHeaders.Add("X-DonemInd", donemInd);
            return client;
        }


        public async Task<IActionResult> Index(string? firmaInd, bool? listele, int page = 1, int pageSize = 10)
        {
            ViewBag.Listele = listele;
            ViewBag.FirmaInd = firmaInd ?? "101";

            if (listele == true)
            {
                using var client = CreateApiClient(firmaInd);
                var response = await client.GetAsync("api/Cari");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var cariler = JsonSerializer.Deserialize<List<CariDto>>(json, options) ?? new List<CariDto>();

                    var totalItems = cariler.Count;
                    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
                    ViewBag.CurrentPage = page;
                    ViewBag.TotalPages = totalPages;
                    ViewBag.PageWindow = 10;

                    var pagedData = cariler.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    return View(pagedData);
                }
            }

            return View(new List<CariDto>());
        }

        public async Task<IActionResult> Details(int id, string? firmaInd)
        {
            using var client = CreateApiClient(firmaInd);
            var response = await client.GetAsync($"api/Cari/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cari = JsonSerializer.Deserialize<DetayDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (cari == null)
                    return NotFound();

                return View(cari);
            }

            return NotFound();
        }

        public async Task<IActionResult> Detay(int faturaInd, string documentType, string firmaInd, string donemInd)
        {
            if (faturaInd <= 0)
                return BadRequest("Fatura IND geçerli bir sayı olmalıdır.");

            firmaInd ??= "101";
            donemInd ??= "0003";

            try
            {
                var strategy = _strategyFactory.GetStrategy(documentType);
                var viewModel = await strategy.GetDocumentAsync(faturaInd, firmaInd, donemInd);
                return View(viewModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }


    public async Task<IActionResult> GetCariHareketleri(int cariId, string? firmaInd)
        {
            using var client = CreateApiClientWithDonem(firmaInd);
            var response = await client.GetAsync($"api/CariHareketleri/{cariId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var hareketler = JsonSerializer.Deserialize<List<CariHareketleriDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

              

                return PartialView("_CariHareketleriPartial", hareketler);
            }

            return NotFound();
        }       
    }
}
