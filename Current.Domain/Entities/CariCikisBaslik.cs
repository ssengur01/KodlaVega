using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.Entities
{
    public class CariCikisBaslik
    {
        public int Ind { get; set; }
        public int? FirmaNo { get; set; }
        public string? BelgeNo { get; set; }
        public DateTime? Tarih { get; set; }
        public bool? Iade { get; set; }
        public decimal? AylıkVade { get; set; }
        public decimal? Tutar { get; set; }
        public string? ParaBirimi { get; set; }
        public int? KapatmaBelgesi { get; set; }
        public bool? Giris { get; set; }
        public decimal? Kur { get; set; }
        public int? BelgeTipi { get; set; }
        public bool? Iptal { get; set; }
        public int? Entegre { get; set; }
        public int? UserNo { get; set; }
        public decimal? KdvIsk { get; set; }
        public string? OzelKod1 { get; set; }
        public string? OzelKod2 { get; set; }
        public string? Aciklama { get; set; }
        public int? KonsolIde { get; set; }
        public bool? Muhasebelesmeyecek { get; set; }
        public string? OzelKod3 { get; set; }
        public string? OzelKod4 { get; set; }
        public DateTime? Credate { get; set; }
        public int? Kaynak { get; set; }
        public string? OzelKod5 { get; set; }
        public string? OzelKod6 { get; set; }
        public string? OzelKod7 { get; set; }
        public string? OzelKod8 { get; set; }
        public bool? HesapKapatmaDisi { get; set; }
        public string? OzelKod9 { get; set; }
        public string? Uıd { get; set; }
    }
}
