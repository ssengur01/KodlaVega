using CurrentDocument.Shared.Enums;

namespace CurrentService.WEBUI.Models
{
    public class CarGirBaslikDto
    {
        public int IND { get; set; }
        public int? FIRMANO { get; set; }
        public string? BELGENO { get; set; }
        public DateTime? TARIH { get; set; }
        public bool? IADE { get; set; }
        public decimal? AYLIKVADE { get; set; }
        public decimal? TUTAR { get; set; }
        public string? PARABIRIMI { get; set; }
        public int? KAPATMABELGESI { get; set; }
        public bool? GIRIS { get; set; }
        public decimal? KUR { get; set; }
        public CurrentType? BELGETIPI { get; set; }
        public bool? IPTAL { get; set; }
        public int? ENTEGRE { get; set; }
        public int? USERNO { get; set; }
        public decimal? KDVISK { get; set; }
        public string? ACIKLAMA { get; set; }
        public int? KONSOLIDE { get; set; }
        public bool? MUHASEBELESMEYECEK { get; set; }
        public DateTime? CREDATE { get; set; }
    }
}
