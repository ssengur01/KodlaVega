using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current.Domain.Entities
{
    public class Cari
    {
        [Column("Ind")]
        public int Ind { get; set; }

        [NotMapped]
        public string? FirmaInd => FirmaKodu;

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
        public bool? Deleted { get; set; }
        public string? Istihbarat { get; set; }
        public string? Unvan { get; set; }
        public int? Sektor { get; set; }
        public int? Marka { get; set; }
        public string? Url { get; set; }
        public string? Telefon1 { get; set; }
        public string? Telefon2 { get; set; }
        public string? Telefon3 { get; set; }
        public string? Faks { get; set; }
        public string? Modem { get; set; }
        public string? AdresPosta { get; set; }
        public string? AdresFatura { get; set; }
        public string? AdresSevk { get; set; }
        public string? Email { get; set; }
        public string? Web { get; set; }
        public string? YetkiliMail { get; set; }
        public string? Ydahil { get; set; }
        public string? YtelFon1 { get; set; }
        public string? YtelFon2 { get; set; }
        public string? Ygsm { get; set; }
        public string? Ymodem { get; set; }
        public string? Kefil1 { get; set; }
        public string? Kefil1Adres { get; set; }
        public string? Kefil1Telefon { get; set; }
        public string? Kefil2 { get; set; }
        public string? Kefil2Adres { get; set; }
        public string? Kefil2Telefon { get; set; }
        public decimal? GecikmeFaizi { get; set; }
        public byte[]? Resim { get; set; }
        public string? ParaBirimi { get; set; }
        public int? PersonelNo { get; set; }
        public int? Status { get; set; }
        public bool? SatisYapilmasin { get; set; }
        public int? Depo { get; set; }
        public int? Zimmet { get; set; }
        public bool? TahsilatYapilmasin { get; set; }
        public string? TckimlikNo { get; set; }
        public string? VergiKimlikNo { get; set; }
        public bool? BagkurCalismasin { get; set; }
        public string? FirmaTakipKodu { get; set; }
        public string? Kefil1TakipKodu { get; set; }
        public string? Kefil2TakipKodu { get; set; }
        public int? OdemeSekli { get; set; }
        public decimal? Prim { get; set; }
        public bool? IadeFaturaSiKesilmesin { get; set; }
        public int? DepoInd { get; set; }
        public string? Il { get; set; }
        public string? Sehir { get; set; }
        public bool? EfaturaKullanicisi { get; set; }
        public int? EfaturaSenaryo { get; set; }
        public int? KrediLimitiKontrol { get; set; }
        public string? Alias { get; set; }
        public decimal? Sermaye { get; set; }
        public string? SicilNo { get; set; }
        public bool? Eticaret { get; set; }
        public DateTime? IseGirisTarihi { get; set; }
        public DateTime? IstenCikisTarihi { get; set; }
        public bool? OdemeYapilmasin { get; set; }
        public string? GrupKodu { get; set; }
        public string? NaceKodu { get; set; }
        public decimal? HedefCiro { get; set; }
        public bool? SmsGonder { get; set; }
        public bool? EmailGonder { get; set; }
        public int? EarsivTeslimTipi { get; set; }
        public string? Kod6 { get; set; }
        public string? Kod7 { get; set; }
        public int? IsletmeTuru { get; set; }
        public string? GlnKodu { get; set; }
        public string? SubeAdi { get; set; }
        public string? Uid { get; set; }
        public bool? AlisYapilmasin { get; set; }
        public bool? SiparisYapilmasin { get; set; }
        public bool? Eirsaliye { get; set; }
        public string? EirsaliyeAlis { get; set; }
        public bool? KdvMuafiyati { get; set; }
        public int? CariPozisyon { get; set; }
        public int? KurTipi { get; set; }
        public bool? AliasGuncellenmesin { get; set; }
        public string? UtsKurumNo { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }

        // public ICollection<CariHareketleri>? _CariHarekletleri { get; set; } = new List<CariHareketleri>();


        // public CariHareketleri _CariHareketleri { get; set; }
    }
}
