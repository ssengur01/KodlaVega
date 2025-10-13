using StockDocument.Shared.Enums;

namespace CurrentService.WEBUI.Models
{
    public class StkGirBaslikDto
    {
        public int IND { get; set; }
        public string? FIRMAADI { get; set; }
        public decimal? TUTAR { get; set; }
        public string? BELGENO { get; set; }
        public DateTime? TARIH { get; set; }
        public bool? KDV { get; set; }
        public DateTime? ODEMETARIHI { get; set; }
        public int? DEPO { get; set; }
        public bool? SUCCESS { get; set; }
        public bool? IADE { get; set; }
        public bool? IPTAL { get; set; }
        public bool? CONVERTED { get; set; }
        public DateTime? CREDATE { get; set; }
        public DateTime? LADATE { get; set; }
        public int? FIRMANO { get; set; }
        public string? PARABIRIMI { get; set; }
        public decimal? KUR { get; set; }
        public decimal? ODENEN { get; set; }
        public bool? GIRIS { get; set; }
        public StockType? BELGETIPI { get; set; }
        public bool? SELECTED { get; set; }
        public int? SATISSEKLI { get; set; }
        public decimal? ARATOPLAM { get; set; }
        public int? STATUS { get; set; }
        public bool? MUHASEBELESMEYECEK { get; set; }
        public int? HAREKETDEPOSU { get; set; }
        public bool? STOKHAREKETEYAZ { get; set; }
        public bool? CARIHAREKETEYAZ { get; set; }
    }
}
