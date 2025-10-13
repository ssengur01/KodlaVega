using CurrentService.WEBUI.Models;
using Document.Shared.Enums;
using System.Text.Json;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class AlFatStrategy : IDocumentStrategy
    {
        private readonly IHttpClientFactory _clientFactory;

        public AlFatStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7059/"); 
            client.DefaultRequestHeaders.Remove("X-FirmaInd");
            client.DefaultRequestHeaders.Add("X-FirmaInd", firmaInd);

            var viewModel = new FaturaViewModel { InvoiceType = InvoiceType.AlFat };

            // Başlık
            var baslikJson = await client.GetStringAsync($"api/AlFatBasliks/GetDetail/{faturaInd}");
            viewModel.AlFatBaslik = JsonSerializer.Deserialize<AlFatBaslikDto>(baslikJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Hareketler
            var hrkJson = await client.GetStringAsync($"api/AlFatHarekets/Hareket/ByEvrakNo?evrakNo={faturaInd}");
            viewModel.AlFatHareketler = JsonSerializer.Deserialize<List<AlFatHareketDto>>(hrkJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return viewModel;
        }
    }
}
