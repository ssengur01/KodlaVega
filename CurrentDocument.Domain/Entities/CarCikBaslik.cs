using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Domain.Entities
{
    public class CarCikBaslik
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
        public int? BELGETIPI { get; set; }
        public bool? IPTAL { get; set; }
        public int? ENTEGRE { get; set; }
        public int? USERNO { get; set; }
        public decimal? KDVISK { get; set; }
        public string? OZELKOD1 { get; set; }
        public string? OZELKOD2 { get; set; }
        public string? ACIKLAMA { get; set; }
        public int? KONSOLIDE { get; set; }
        public bool? MUHASEBELESMEYECEK { get; set; }
        public string? OZELKOD3 { get; set; }
        public string? OZELKOD4 { get; set; }
        public DateTime? CREDATE { get; set; }
        public int? KAYNAK { get; set; }
        public string? OZELKOD5 { get; set; }
        public string? OZELKOD6 { get; set; }
        public string? OZELKOD7 { get; set; }
        public string? OZELKOD8 { get; set; }
        public bool? HESAPKAPATMADISI { get; set; }
        public string? OZELKOD9 { get; set; }
        public string? UID { get; set; }
    }
}
