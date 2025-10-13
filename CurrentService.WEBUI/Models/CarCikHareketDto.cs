namespace CurrentService.WEBUI.Models
{
    public class CarCikHareketDto
    {
        public int Ind { get; set; }
        public int? Izahat { get; set; }
        public int? PortNo { get; set; }
        public int? EvrakNo { get; set; }
        public string? Aciklama { get; set; }
        public DateTime? Vade { get; set; }
        public decimal? Tutar { get; set; }
        public string? ParaBirimi { get; set; }
        public string? BelgeNo { get; set; }
        public int? Status { get; set; }
        public decimal? Kur { get; set; }
        public int? BankaNo { get; set; }
        public int? FirmaNo { get; set; }
        public string? MuhHesapKodu { get; set; }
        public decimal? AylikVade { get; set; }
    }
}
