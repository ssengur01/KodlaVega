using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.DTOs
{
    public class CariGirisHareketDto
    {
        public int? Izahat { get; set; }
        public int? PortNo { get; set; }
        public int? EvrakNo { get; set; }
        public string? Aciklama { get; set; }
        public DateTime? Vade { get; set; }
        public decimal? Tutar { get; set; }
        public string? ParaBirimi { get; set; }
        public string? BelgeNo { get; set; }
        public int? BelgeLink { get; set; }
        public int? Status { get; set; }
        public decimal? Kur { get; set; }
        public int? BankaNo { get; set; }
        public int? FirmaNo { get; set; }
        public int? VisaTahsilHareketNo { get; set; }
        public string? MuhHesapKodu { get; set; }
        public DateTime? GercekVade { get; set; }
        public decimal? AylikVade { get; set; }
        public string? Aciklama2 { get; set; }
    }
}
