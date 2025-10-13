using CurrentDocument.Shared.Enums;
using CurrentService.WEBUI.Models;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class CarCikStrategy : IDocumentStrategy
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarCikStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { CurrentType = CurrentType.CarÇık };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/CarCikBasliks/GetDetail/{faturaInd}");
            viewModel.CarCikBaslik = JsonSerializer.Deserialize<CarCikBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/CarCikHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.CarCikHareketler = JsonSerializer.Deserialize<List<CarCikHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
