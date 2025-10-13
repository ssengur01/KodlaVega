using CurrentService.WEBUI.Models;

namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public interface IDocumentStrategy
    {
        Task<FaturaViewModel> GetDocumentAsync(int faturaInd, string firmaInd, string donemInd);
    }
}
