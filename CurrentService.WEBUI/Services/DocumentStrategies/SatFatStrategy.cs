using CurrentService.WEBUI.Models;
using Document.Shared.Enums;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class SatFatStrategy : IDocumentStrategy
    {
        private readonly IHttpClientFactory _clientFactory;

        public SatFatStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7059/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { InvoiceType = InvoiceType.SatFat };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/SatFatBasliks/GetDetail/{faturaInd}");
            viewModel.SatFatBaslik = JsonSerializer.Deserialize<SatFatBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/SatFatHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.SatFatHareketler = JsonSerializer.Deserialize<List<SatFatHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
