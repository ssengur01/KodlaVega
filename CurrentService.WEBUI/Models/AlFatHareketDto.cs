namespace CurrentService.WEBUI.Models
{
    public class AlFatHareketDto
    {
        public int Ind { get; set; }
        public string? StokKodu { get; set; }
        public string? MalinCinsi { get; set; }
        public decimal? Miktar { get; set; }
        public string? Birim { get; set; }
        public decimal? Fiyati { get; set; }
        public decimal? Indirim { get; set; }
        public short? Kdv { get; set; }
        public decimal? KdvTutari { get; set; }
        public decimal? SatirToplam { get; set; }
        public string? Aciklama { get; set; }
    }
}
