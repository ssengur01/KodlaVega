using CurrentDocument.Shared.Enums;
using CurrentService.WEBUI.Models;
using Document.Shared.Enums;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class CarGirStrategy : IDocumentStrategy
    {

        private readonly IHttpClientFactory _clientFactory;

        public CarGirStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { CurrentType = CurrentType.CarGir };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/CarGirBasliks/GetDetail/{faturaInd}");
            viewModel.CarGirBaslik = JsonSerializer.Deserialize<CarGirBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/CarGirHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.CarGirHareketler = JsonSerializer.Deserialize<List<CarGirHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
