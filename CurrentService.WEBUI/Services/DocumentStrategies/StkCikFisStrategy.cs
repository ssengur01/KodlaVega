using CurrentService.WEBUI.Models;
using StockDocument.Shared.Enums;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class StkCikFisStrategy : IDocumentStrategy
    {
        private IHttpClientFactory _clientFactory;

        public StkCikFisStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { StockType = StockType.StkÇıkışFişi };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/StkCikBasliks/GetDetail/{faturaInd}");
            viewModel.StkCikBaslik = JsonSerializer.Deserialize<StkCikBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/StkCikHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.StkCikHareketler = JsonSerializer.Deserialize<List<StkCikHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
