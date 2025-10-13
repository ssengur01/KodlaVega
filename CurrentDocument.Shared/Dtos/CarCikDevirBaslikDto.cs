using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Shared.Dtos
{
    public class CarCikDevirBaslikDto
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
        public string? ACIKLAMA { get; set; }
        public int? KONSOLIDE { get; set; }
        public bool? MUHASEBELESMEYECEK { get; set; }
        public DateTime? CREDATE { get; set; }
    }
}
