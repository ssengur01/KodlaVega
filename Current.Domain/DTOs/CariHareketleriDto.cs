using CurrentDocument.Shared.Enums;
using Document.Shared.Enums;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Current.Domain.DTOs
{
    public class CariHareketleriDto
    {
        public int? FirmaNo { get; set; }
        public DateTime? Tarih { get; set; }
        public string? Izahat { get; set; }
        public string? EvrakNo { get; set; }
        public decimal? Borc { get; set; }
        public decimal? Alacak { get; set; }
        public decimal? Bakiye { get; set; }
        public int? Ln { get; set; }
        public int? FaturaInd => Ln;
        public bool? Iade { get; set; }
        public int? Ln2 { get; set; }
        public int? ConvNum { get; set; }
        public int? ConvStyle { get; set; }
        public string? ParaBirimi { get; set; }
        public decimal? Kur { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime? IslemTarihi { get; set; }
        public DateTime? SiralamaTarihi { get; set; }
        public string? OzelKod { get; set; }
        public decimal? SiralamaTarihiEx { get; set; }
        public string? IzahatFromFunction { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public  CurrentType CurrentType { get; set; }
        public StockType StockType { get; set; }
    }
}
