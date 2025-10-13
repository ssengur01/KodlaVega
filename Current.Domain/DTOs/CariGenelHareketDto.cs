using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.DTOs
{
    public class CariGenelHareketDto
    {
        public int? FirmaNo { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? Vade { get; set; }
        public int? BelgeInd { get; set; }
        public int? IslemInd { get; set; }
        public int? BelgeIzahat { get; set; }
        public int? IslemIzahat { get; set; }
        public int? BelgeLink { get; set; }
        public decimal? Borc { get; set; }
        public decimal? Alacak { get; set; }
        public decimal? AylıkVade { get; set; }
        public string? BelgeNo { get; set; }
        public string? IslemNo { get; set; }
        public bool? Converted { get; set; }
        public bool? Iptal { get; set; }
        public DateTime? SıralamaTarihi { get; set; }
        public int? TahsilLink { get; set; }
        public bool? GecikmeHesapla { get; set; }
        public string? ParaBirimi { get; set; }
        public decimal? Kur { get; set; }
        public string? BaslikParaBirimi { get; set; }
        public decimal? BaslikKuru { get; set; }
        public string? Aciklama { get; set; }
        public decimal? SıralamaTarihiEx { get; set; }
    }
}
