using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Document.Domain.Entities
{
    public class AlFatBaslik
    {
        public int IND {get;set;}
        public string? FIRMAADI {get;set;}
        public decimal? TUTAR  {get;set;}
        public string? BELGENO {get;set;}
        public DateTime? TARIH  {get;set;}
        public bool? KDV  {get;set;}
        public bool? AK {get;set;}
        public bool? ENVANTERUPDATE {get;set;}
        public DateTime? ODEMETARIHI {get;set;}
        public bool? ODMODIFIED {get;set;}
        public string? ALTBELGENO {get;set;}
        public DateTime? ALTBELGETARIHI {get;set;}
        public decimal? ALT1 {get;set;}
        public decimal? ALT2 {get;set;}
        public decimal? ALT3 {get;set;}
        public decimal? ALT4 {get;set;}
        public int? DEPO {get;set;}
        public bool? SUCCESS {get;set;}
        public string? ALTNOT {get;set;}
        public int? OZELKOD {get;set;}
        public string? OZELKOD1 {get;set;}
        public string? OZELKOD2 {get;set;}
        public decimal? KALEM1 {get;set;}
        public decimal? KALEM2 {get;set;}
        public decimal? KALEM3 {get;set;}
        public decimal? KALEM4 {get;set;}
        public bool? IADE {get;set;}
        public bool? IPTAL {get;set;}
        public bool? CONVERTED {get;set;}
        public DateTime? CREDATE {get;set;}
        public DateTime? LADATE {get;set;}
        public int? FIRMANO {get;set;}
        public string? PARABIRIMI {get;set;}
        public decimal? KUR {get;set;}
        public decimal? YUVARLAMA {get;set;}
        public bool? ALLOWYUVARLAMA {get;set;}
        public decimal? ODENEN {get;set;}
        public bool? GIRIS {get;set;}
        public short? BELGETIPI {get;set;}
        public short? EKBELGETIPI {get;set;}
        public bool? SELECTED {get;set;}
        public decimal? MASRAF1 {get;set;}
        public decimal? MASRAF2 {get;set;}
        public decimal? MASRAF3 {get;set;}
        public decimal? MASRAF4 {get;set;}
        public short? MASRAFKDV1 {get;set;}
        public short? MASRAFKDV2 {get;set;}
        public short? MASRAFKDV3 {get;set;}
        public short? MASRAFKDV4 {get;set;}
        public int? ENTEGRE {get;set;}
        public int? USERNO {get;set;}
        public decimal? KDVISK {get;set;}
        public int? SATISSEKLI {get;set;}
        public decimal? ARATOPLAM {get;set;}
        public int? KONSOLIDE {get;set;}
        public int? ODEMEOPSIYONU {get;set;}
        public decimal? TEVKIFATORAN {get;set;}
        public int? STATUS {get;set;}
        public bool? YURTDISI {get;set;}
        public bool? MUHASEBELESMEYECEK {get;set;}
        public string? OZELKOD3 {get;set;}
        public string? OZELKOD4 {get;set;}
        public string? PESINFIRMAADI {get;set;}
        public string? PESINADRES {get;set;}
        public string? PESINVERGIDAIRESI {get;set;}
        public string? PESINVERGINO {get;set;}
        public int? HAREKETDEPOSU {get;set;}
        public int? KAYNAK {get;set;}
        public string? OZELKOD5 {get;set;}
        public string? OZELKOD6 {get;set;}
        public string? OZELKOD7 {get;set;}
        public string? OZELKOD8 {get;set;}
        public string? ALAN1 {get;set;}
        public string? ALAN2 {get;set;}
        public bool? EFATURA {get;set;}
        public string? EFATURANO {get;set;}
        public string? EFATURAUUID {get;set;}
        public string? EFATURANUMBER {get;set;}
        public int? EFATURASTATE {get;set;}
        public string? OZELKOD9 {get;set;}
        public bool? STOKHAREKETEYAZ {get;set;}
        public bool? CARIHAREKETEYAZ {get;set;}
        public bool? IRSALIYELIFATURA {get;set;}
        public bool? YAZARKASAFISI {get;set;}
        public string? UID {get;set;}
        public int? IntegrationFolder {get;set;}
        public int? SENTSTATUS {get;set;}
        public string? PESINMAIL { get; set; }        
        
      //  public ICollection<AlFatHareket>? AlFatHarekets {get; set;}
    }
}
