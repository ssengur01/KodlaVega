namespace CurrentService.WEBUI.Models
{
    public class StkCikHareketDto
    {
        public int Ind { get; set; }
        public DateTime? Tarih { get; set; }
        public int? Detay { get; set; }
        public bool? Selected { get; set; }
        public int? EvrakNo { get; set; }
        public int? FirmaNo { get; set; }
        public int? StokNo { get; set; }
        public string? MalinCinsi { get; set; }
        public string? StokKodu { get; set; }
        public int? StokTipi { get; set; }
        public decimal? Miktar { get; set; }
        public string? Birim { get; set; }
        public short? Kdv { get; set; }
        public decimal? Fiyati { get; set; }
        public decimal? GercekToplam { get; set; }
        public int? Depo { get; set; }
        public int? Personel { get; set; }
        public decimal? Pirim { get; set; }
        public DateTime? Termin { get; set; }
        public int? Taksit { get; set; }
        public string? ParaBirimi { get; set; }
        public string? Aciklama { get; set; }
        public string? KampanyaAciklamasi { get; set; }
    }
}
