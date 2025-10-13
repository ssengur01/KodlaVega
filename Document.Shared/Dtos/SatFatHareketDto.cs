using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Shared.Dtos
{
    public class SatFatHareketDto
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
        public decimal? BirimMiktar { get; set; }
        public string? Birim { get; set; }
        public int? BirimEx { get; set; }
        public short? Kdv { get; set; }
        public decimal? KdvTutari { get; set; }
        public decimal? Isk1 { get; set; }
        public decimal? Isk2 { get; set; }
        public decimal? Isk3 { get; set; }
        public decimal? Isk4 { get; set; }
        public decimal? AFiyatı { get; set; }
        public decimal? Fiyati { get; set; }
        public decimal? GercekToplam { get; set; }
        public int? Depo { get; set; }
        public int? Personel { get; set; }
        public decimal? Pirim { get; set; }
        public int? Opsiyon { get; set; }
        public int? Promosyon { get; set; }
        public int? SatisKosulu { get; set; }
        public decimal? SeriMiktar { get; set; }
        public decimal? Envanter { get; set; }
        public string? KarsiStokKodu { get; set; }
        public string? KarsiBarkod { get; set; }
        public DateTime? Termin { get; set; }
        public int? Taksit { get; set; }
        public string? ParaBirimi { get; set; }
        public decimal? Kur { get; set; }
        public string? Barkod { get; set; }
        public decimal? Pesinat { get; set; }
        public decimal? Masraf { get; set; }
        public decimal? MasrafKdv { get; set; }
        public string? Aciklama { get; set; }
    }
}
