using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.DTOs
{
    public class CariDto
    {
        public int Ind { get; set; }
        public string? FirmaInd { get; set; }
        public int? FirmaNo { get; set; }
        public string? FirmaKodu { get; set; }
        public string? FirmaAdi { get; set; }
        public string? Yetkili { get; set; }
        public string? VergiDairesi { get; set; }
        public string? VergiNo { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public decimal? RiskLimiti { get; set; }
        public decimal? KrediLimiti { get; set; }
        public decimal? Iskonto { get; set; }
        public decimal? Ayvilade { get; set; }
        public int? Opsiyon { get; set; }
        public int? FirmaTipi { get; set; }
        public int? Statu { get; set; }
        public decimal? OdemeBayKesi { get; set; }
        public decimal? Bakiye { get; set; }
        public string? Kod1 { get; set; }
        public string? Kod2 { get; set; }
        public string? Kod3 { get; set; }
        public string? Kod4 { get; set; }
        public string? Kod5 { get; set; }
        public string? Soyadi { get; set; }
        public string? Adi { get; set; }
        public string? Unvan { get; set; }
        public int? Sektor { get; set; }
        public string? Telefon1 { get; set; }
        public string? Telefon2 { get; set; }
        public string? Telefon3 { get; set; }
        public string? AdresPosta { get; set; }
        public string? AdresFatura { get; set; }
        public string? AdresSevk { get; set; }
        public string? Email { get; set; }
        public string? ParaBirimi { get; set; }
        public int? Status { get; set; }
        public bool? SatisYapilmasin { get; set; }
        public string? Il { get; set; }
        public string? Sehir { get; set; }
        public bool? EfaturaKullanicisi { get; set; }
        public int? EfaturaSenaryo { get; set; }
        public int? KrediLimitiKontrol { get; set; }
        public string? Alias { get; set; }
    }
}
