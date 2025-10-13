using Document.Domain.Entities;
using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Shared.Dtos
{
    public class SatFatBaslikDto
    {
        public int IND { get; set; }
        public string? FIRMAADI { get; set; }
        public decimal? TUTAR { get; set; }
        public string? BELGENO { get; set; }
        public DateTime? TARIH { get; set; }
        public bool? KDV { get; set; }
        public bool? AK { get; set; }
        public bool? ENVANTERUPDATE { get; set; }
        public DateTime? ODEMETARIHI { get; set; }
        public bool? ODMODIFIED { get; set; }
        public string? ALTBELGENO { get; set; }
        public DateTime? ALTBELGETARIHI { get; set; }
        public decimal? ALT1 { get; set; }
        public decimal? ALT2 { get; set; }
        public decimal? ALT3 { get; set; }
        public decimal? ALT4 { get; set; }
        public int? DEPO { get; set; }
        public bool? SUCCESS { get; set; }
        public string? ALTNOT { get; set; }
        public int? OZELKOD { get; set; }
        public string? OZELKOD1 { get; set; }
        public string? OZELKOD2 { get; set; }
        public decimal? KALEM1 { get; set; }
        public decimal? KALEM2 { get; set; }
        public decimal? KALEM3 { get; set; }
        public decimal? KALEM4 { get; set; }
        public bool? IADE { get; set; }
        public bool? IPTAL { get; set; }
        public bool? CONVERTED { get; set; }
        public DateTime? CREDATE { get; set; }
        public DateTime? LADATE { get; set; }
        public int? FIRMANO { get; set; }
        public string? PARABIRIMI { get; set; }
        public decimal? KUR { get; set; }
        public decimal? YUVARLAMA { get; set; }
        public bool? ALLOWYUVARLAMA { get; set; }
        public decimal? ODENEN { get; set; }
        public bool? GIRIS { get; set; }
        public InvoiceType? BELGETIPI { get; set; }
        public short? EKBELGETIPI { get; set; }
        public bool? SELECTED { get; set; }
        public decimal? MASRAF1 { get; set; }
        public decimal? MASRAF2 { get; set; }
        public decimal? MASRAF3 { get; set; }
        public decimal? MASRAF4 { get; set; }
        public short? MASRAFKDV1 { get; set; }
        public short? MASRAFKDV2 { get; set; }
        public short? MASRAFKDV3 { get; set; }
        public short? MASRAFKDV4 { get; set; }
        public decimal? TAHSILATTUTARI { get; set; }
        public int? ENTEGRE { get; set; }
        public int? USERNO { get; set; }
        public decimal? KDVISK { get; set; }
        public int? SATISSEKLI { get; set; }
        public decimal? ARATOPLAM { get; set; }
        public int? KONSOLIDE { get; set; }
        public int? ODEMEOPSIYONU { get; set; }
        public decimal? TEVKIFATORAN { get; set; }
        public int? STATUS { get; set; }

        public SatFatBaslikDto()
        {
        }

        public SatFatBaslikDto(SatFatBaslik entity)
        {
            IND = entity.IND;
            FIRMAADI = entity.FIRMAADI;
            TUTAR = entity.TUTAR;
            BELGENO = entity.BELGENO;
            TARIH = entity.TARIH;
            BELGETIPI = (InvoiceType?)entity.BELGETIPI;
        }
    }
}
