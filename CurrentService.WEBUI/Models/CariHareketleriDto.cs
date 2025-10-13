using CurrentDocument.Shared.Enums;
using Document.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrentService.WEBUI.Models
{
    public class CariHareketleriDto
    {
        public int? Ind { get; set; }
        public int? FirmaNo { get; set; }
        public DateTime? Tarih { get; set; }
        public string? Izahat { get; set; }
        public string? EvrakNo { get; set; }
        public int? Ln { get; set; }
        public decimal? Borc { get; set; }
        public decimal? Alacak { get; set; }
        public decimal? Bakiye { get; set; }
        public string? ParaBirimi { get; set; }
        public decimal? Kur { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime? IslemTarihi { get; set; }
        public DateTime? SiralamaTarihi { get; set; }
        public string? IzahatFromFunction { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public CurrentType? CurrentType { get; set; }
    }
}
