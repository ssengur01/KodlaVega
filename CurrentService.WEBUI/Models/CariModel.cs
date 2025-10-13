using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CurrentService.WEBUI.Models
{
    public class CariModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CariModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public List<CariDto> Cariler { get; set; } = new();
        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("CurrentServiceApi");
            var response = await client.GetAsync("api/Cari");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Cariler = JsonSerializer.Deserialize<List<CariDto>>(data, options) ?? new();
            }
            else
            {
                Cariler = new();
            }
        }
    }
}
