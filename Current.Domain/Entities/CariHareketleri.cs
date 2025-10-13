using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.Entities
{
    public class CariHareketleri
    {
        public int Ind { get; set; }

        [Column("FirmaNo")]
        public int? FirmaNo { get; set; }
        public DateTime? Tarih { get; set; }
        public string? Izahat { get; set; }
        public string? EvrakNo { get; set; }
        public decimal? Borc { get; set; }
        public decimal? Alacak { get; set; }
        public decimal? Bakiye { get; set; }
        public int? Ln { get; set; }
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

        // [ForeignKey("FirmaNo")]
        // public Cari? _Cari { get; set; }

    }
}
