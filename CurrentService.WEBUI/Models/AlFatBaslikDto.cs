using Document.Shared.Enums;

namespace CurrentService.WEBUI.Models
{
    public class AlFatBaslikDto 
    {
        public int Ind { get; set; }
        public string? BelgeNo { get; set; }
        public DateTime? Tarih { get; set; }
        public string? FirmaAdi { get; set; }
        public decimal? AraToplam { get; set; }
        public decimal? GenelToplam { get; set; }
        public string? ParaBirimi { get; set; }
        public decimal? Kur { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public bool? Kdv { get; set; }
        public bool? Iade { get; set; }
        public bool? Iptal { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }
        public int? KullaniciNo { get; set; }
       
    }
}
