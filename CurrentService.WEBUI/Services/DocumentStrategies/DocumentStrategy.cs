namespace CurrentService.WEBUI.Services.DocumentStrategies
{
    public class DocumentStrategy
    {
        private readonly IHttpClientFactory _clientFactory;

        public DocumentStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IDocumentStrategy GetStrategy(string documentType)
        {
            return documentType switch
            {
                "AlFat" => new AlFatStrategy(_clientFactory),
                "SatFat" => new SatFatStrategy(_clientFactory),
                "CarGir" => new CarGirStrategy(_clientFactory),
                "CarÇık" => new CarCikStrategy(_clientFactory),
                "StkGirişFişi" => new StkGirFisStrategy(_clientFactory),
                "StkÇıkışFişi" => new StkCikFisStrategy(_clientFactory),
                _ => throw new ArgumentException("Geçersiz belge tipi")
            };
        }
    }
}
