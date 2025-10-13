using CurrentService.WEBUI.Models;
using StockDocument.Shared.Enums;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class StkGirFisStrategy : IDocumentStrategy
    {
        private readonly IHttpClientFactory _clientFactory;

        public StkGirFisStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7182/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { StockType = StockType.StkGirişFişi };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/StkGirBasliks/GetDetail/{faturaInd}");
            viewModel.StkGirBaslik = JsonSerializer.Deserialize<StkGirBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/StkGirHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.StkGirHareketler = JsonSerializer.Deserialize<List<StkGirHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
