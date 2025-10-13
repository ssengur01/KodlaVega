using CurrentDocument.Shared.Enums;
using Document.Shared.Enums;
using StockDocument.Shared.Enums;

namespace CurrentService.WEBUI.Models
{
    public class FaturaViewModel
    {
        public InvoiceType InvoiceType { get; set; }
        public CurrentType CurrentType { get; set; }
        public StockType StockType { get; set; }
     
        public AlFatBaslikDto? AlFatBaslik { get; set; }
        public SatFatBaslikDto? SatFatBaslik { get; set; }

        public CarGirBaslikDto? CarGirBaslik { get; set; }
        public CarCikBaslikDto? CarCikBaslik { get; set; }

        public StkGirBaslikDto? StkGirBaslik { get; set; }
        public StkCikBaslikDto? StkCikBaslik{ get; set; }

        public List<AlFatHareketDto>? AlFatHareketler { get; set; } = new();
        public List<SatFatHareketDto>? SatFatHareketler { get; set; } = new();

        public List<StkCikHareketDto>? StkCikHareketler { get; set; } = new();
        public List<StkGirHareketDto>? StkGirHareketler { get; set; } = new();

        public List<CarGirHareketDto>? CarGirHareketler { get; set; } = new();
        public List<CarCikHareketDto>? CarCikHareketler { get; set; } = new();
    }
}
