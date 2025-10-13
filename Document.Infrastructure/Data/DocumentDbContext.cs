using Document.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Infrastructure.Data
{
    public class DocumentDbContext : DbContext
    {
        private readonly string _firmaInd;
        private readonly string _donemInd;

        public DocumentDbContext(DbContextOptions<DocumentDbContext> options, FirmaDonemContext firmaContext)
        : base(options)
        {
            _firmaInd = "101";
            _donemInd = "0003";
        }

        public DbSet<Firma> TBLFIRMA { get; set; }
        public DbSet<Donem> TBLDONEM { get; set; }

        public DbSet<AlFatBaslik> AlFatBasliklar { get; set; }
        public DbSet<AlFatHareket> AlFatHareketler { get; set; }
        public DbSet<SatFatBaslik> SatFatBasliklar { get; set; }
        public DbSet<SatFatHareket> SatFatHareketler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Firma>().ToTable("TBLFIRMA");
            modelBuilder.Entity<Firma>().HasKey(f => f.IND);

            modelBuilder.Entity<Donem>(entity =>
            {
                entity.ToTable("TBLDONEM");
                entity.HasKey(d => d.IND);

                entity.Property(d => d.FIND).HasColumnName("FIND");
                entity.Property(d => d.DONEM).HasColumnName("DONEM");
            });

            modelBuilder.Entity<AlFatBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLALFATBASLIK");
                entity.HasKey(e => e.IND);
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMAADI).HasColumnName("FIRMAADI").HasMaxLength(200);
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.KDV).HasColumnName("KDV");
                entity.Property(e => e.AK).HasColumnName("AK");
                entity.Property(e => e.ENVANTERUPDATE).HasColumnName("ENVANTERUPDATE");
                entity.Property(e => e.ODEMETARIHI).HasColumnName("ODEMETARIHI");
                entity.Property(e => e.ODMODIFIED).HasColumnName("ODMODIFIED");
                entity.Property(e => e.ALTBELGENO).HasColumnName("ALTBELGENO").HasMaxLength(50);
                entity.Property(e => e.ALTBELGETARIHI).HasColumnName("ALTBELGETARIHI");
                entity.Property(e => e.ALT1).HasColumnName("ALT1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT2).HasColumnName("ALT2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT3).HasColumnName("ALT3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT4).HasColumnName("ALT4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.DEPO).HasColumnName("DEPO");
                entity.Property(e => e.SUCCESS).HasColumnName("SUCCESS");
                entity.Property(e => e.ALTNOT).HasColumnName("ALTNOT").HasMaxLength(500);
                entity.Property(e => e.OZELKOD).HasColumnName("OZELKOD");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.KALEM1).HasColumnName("KALEM1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM2).HasColumnName("KALEM2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM3).HasColumnName("KALEM3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM4).HasColumnName("KALEM4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.CONVERTED).HasColumnName("CONVERTED");
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.LADATE).HasColumnName("LADATE");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.YUVARLAMA).HasColumnName("YUVARLAMA").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALLOWYUVARLAMA).HasColumnName("ALLOWYUVARLAMA");
                entity.Property(e => e.ODENEN).HasColumnName("ODENEN").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.EKBELGETIPI).HasColumnName("EKBELGETIPI");
                entity.Property(e => e.SELECTED).HasColumnName("SELECTED");
                entity.Property(e => e.MASRAF1).HasColumnName("MASRAF1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF2).HasColumnName("MASRAF2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF3).HasColumnName("MASRAF3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF4).HasColumnName("MASRAF4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAFKDV1).HasColumnName("MASRAFKDV1");
                entity.Property(e => e.MASRAFKDV2).HasColumnName("MASRAFKDV2");
                entity.Property(e => e.MASRAFKDV3).HasColumnName("MASRAFKDV3");
                entity.Property(e => e.MASRAFKDV4).HasColumnName("MASRAFKDV4");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.SATISSEKLI).HasColumnName("SATISSEKLI");
                entity.Property(e => e.ARATOPLAM).HasColumnName("ARATOPLAM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.ODEMEOPSIYONU).HasColumnName("ODEMEOPSIYONU");
                entity.Property(e => e.TEVKIFATORAN).HasColumnName("TEVKIFATORAN").HasColumnType("decimal(28,8)");
                entity.Property(e => e.STATUS).HasColumnName("STATUS");
                entity.Property(e => e.YURTDISI).HasColumnName("YURTDISI");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.PESINFIRMAADI).HasColumnName("PESINFIRMAADI").HasMaxLength(200);
                entity.Property(e => e.PESINADRES).HasColumnName("PESINADRES").HasMaxLength(200);
                entity.Property(e => e.PESINVERGIDAIRESI).HasColumnName("PESINVERGIDAIRESI").HasMaxLength(100);
                entity.Property(e => e.PESINVERGINO).HasColumnName("PESINVERGINO").HasMaxLength(50);
                entity.Property(e => e.HAREKETDEPOSU).HasColumnName("HAREKETDEPOSU");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.ALAN1).HasColumnName("ALAN1").HasMaxLength(200);
                entity.Property(e => e.ALAN2).HasColumnName("ALAN2").HasMaxLength(200);
                entity.Property(e => e.EFATURA).HasColumnName("EFATURA");
                entity.Property(e => e.EFATURANO).HasColumnName("EFATURANO").HasMaxLength(50);
                entity.Property(e => e.EFATURAUUID).HasColumnName("EFATURAUUID").HasMaxLength(100);
                entity.Property(e => e.EFATURANUMBER).HasColumnName("EFATURANUMBER").HasMaxLength(50);
                entity.Property(e => e.EFATURASTATE).HasColumnName("EFATURASTATE");
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.STOKHAREKETEYAZ).HasColumnName("STOKHAREKETEYAZ");
                entity.Property(e => e.CARIHAREKETEYAZ).HasColumnName("CARIHAREKETEYAZ");
                entity.Property(e => e.IRSALIYELIFATURA).HasColumnName("IRSALIYELIFATURA");
                entity.Property(e => e.YAZARKASAFISI).HasColumnName("YAZARKASAFISI");
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
                entity.Property(e => e.IntegrationFolder).HasColumnName("IntegrationFolder");
                entity.Property(e => e.SENTSTATUS).HasColumnName("SENTSTATUS");
                entity.Property(e => e.PESINMAIL).HasColumnName("PESINMAIL").HasMaxLength(100);
            });


            modelBuilder.Entity<AlFatHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLALFATHAREKET");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Detay).HasColumnName("DETAY");
                entity.Property(e => e.Selected).HasColumnName("SELECTED");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.StokNo).HasColumnName("STOKNO");
                entity.Property(e => e.MalinCinsi).HasColumnName("MALINCINSI").HasMaxLength(50);
                entity.Property(e => e.StokKodu).HasColumnName("STOKKODU").HasMaxLength(50);
                entity.Property(e => e.StokTipi).HasColumnName("STOKTIPI");
                entity.Property(e => e.Miktar).HasColumnName("MIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BirimMiktar).HasColumnName("BIRIMMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Birim).HasColumnName("BIRIM").HasMaxLength(10);
                entity.Property(e => e.BirimEx).HasColumnName("BIRIMEX");
                entity.Property(e => e.Kdv).HasColumnName("KDV");
                entity.Property(e => e.KdvTutari).HasColumnName("KDVTUTARI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk1).HasColumnName("ISK1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk2).HasColumnName("ISK2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk3).HasColumnName("ISK3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk4).HasColumnName("ISK4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.AFiyatı).HasColumnName("AFIYATI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Fiyati).HasColumnName("FIYATI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GercekToplam).HasColumnName("GERCEKTOPLAM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Depo).HasColumnName("DEPO");
                entity.Property(e => e.Personel).HasColumnName("PERSONEL");
                entity.Property(e => e.Pirim).HasColumnName("PIRIM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Opsiyon).HasColumnName("OPSIYON");
                entity.Property(e => e.Promosyon).HasColumnName("PROMOSYON");
                entity.Property(e => e.SatisKosulu).HasColumnName("SATISKOSULU");
                entity.Property(e => e.SeriMiktar).HasColumnName("SERIMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Envanter).HasColumnName("ENVANTER").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KarsiStokKodu).HasColumnName("KARSISTOKKODU").HasMaxLength(50);
                entity.Property(e => e.KarsiBarkod).HasColumnName("KARSIBARKOD").HasMaxLength(50);
                entity.Property(e => e.Termin).HasColumnName("TERMIN");
                entity.Property(e => e.Taksit).HasColumnName("TAKSIT");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Barkod).HasColumnName("BARKOD").HasMaxLength(50);
                entity.Property(e => e.Pesinat).HasColumnName("PESINAT").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Masraf).HasColumnName("MASRAF").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MasrafKdv).HasColumnName("MASRAFKDV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.PAciklama).HasColumnName("PACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.OIV).HasColumnName("OIV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Indirim).HasColumnName("INDIRIM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OTV).HasColumnName("OTV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.HurdaIndirimi).HasColumnName("HURDAINDIRIMI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GumrukVergisi).HasColumnName("GUMRUKVERGISI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.DigerVergiler).HasColumnName("DIGERVERGILER").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MiktarStr).HasColumnName("MIKTARSTR").HasMaxLength(50);
                entity.Property(e => e.Gk).HasColumnName("GK");
                entity.Property(e => e.GrupMiktar).HasColumnName("GRUPMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TartilanMiktar).HasColumnName("TARTILANMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Mf).HasColumnName("MF").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK1).HasColumnName("ITSISK1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK2).HasColumnName("ITSISK2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK3).HasColumnName("ITSISK3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK4).HasColumnName("ITSISK4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OrjFiyat).HasColumnName("ORJFIYAT").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GMiktar).HasColumnName("GMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Kod1).HasColumnName("KOD1").HasMaxLength(50);
                entity.Property(e => e.Isk5).HasColumnName("ISK5").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk6).HasColumnName("ISK6").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Uıd).HasColumnName("UID").HasMaxLength(50);
                entity.Property(e => e.OtvMaTrahi).HasColumnName("OTVMATRAHI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Kdv_ExMaTrahi).HasColumnName("KDV_EXMATRAHI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.SatirNo).HasColumnName("SATIRNO");
                entity.Property(e => e.TevkiFatUyg).HasColumnName("TEVKIFATUYG");
                entity.Property(e => e.TevkiFatTutar).HasColumnName("TEVKIFATTUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.LinkBelgeInd).HasColumnName("LINKBELGEIND");
                entity.Property(e => e.LinkBelgeIzahat).HasColumnName("LINKBELGEIZAHAT");
                entity.Property(e => e.KampanyaAciklamasi).HasColumnName("KAMPANYAACIKLAMASI").HasMaxLength(500);
            });

            modelBuilder.Entity<SatFatBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLSATFATBASLIK");
                entity.HasKey(e => e.IND);
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMAADI).HasColumnName("FIRMAADI").HasMaxLength(200);
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.KDV).HasColumnName("KDV");
                entity.Property(e => e.AK).HasColumnName("AK");
                entity.Property(e => e.ENVANTERUPDATE).HasColumnName("ENVANTERUPDATE");
                entity.Property(e => e.ODEMETARIHI).HasColumnName("ODEMETARIHI");
                entity.Property(e => e.ODMODIFIED).HasColumnName("ODMODIFIED");
                entity.Property(e => e.ALTBELGENO).HasColumnName("ALTBELGENO").HasMaxLength(50);
                entity.Property(e => e.ALTBELGETARIHI).HasColumnName("ALTBELGETARIHI");
                entity.Property(e => e.ALT1).HasColumnName("ALT1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT2).HasColumnName("ALT2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT3).HasColumnName("ALT3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALT4).HasColumnName("ALT4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.DEPO).HasColumnName("DEPO");
                entity.Property(e => e.SUCCESS).HasColumnName("SUCCESS");
                entity.Property(e => e.ALTNOT).HasColumnName("ALTNOT").HasMaxLength(500);
                entity.Property(e => e.OZELKOD).HasColumnName("OZELKOD");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.KALEM1).HasColumnName("KALEM1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM2).HasColumnName("KALEM2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM3).HasColumnName("KALEM3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KALEM4).HasColumnName("KALEM4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.CONVERTED).HasColumnName("CONVERTED");
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.LADATE).HasColumnName("LADATE");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.YUVARLAMA).HasColumnName("YUVARLAMA").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ALLOWYUVARLAMA).HasColumnName("ALLOWYUVARLAMA");
                entity.Property(e => e.ODENEN).HasColumnName("ODENEN").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.EKBELGETIPI).HasColumnName("EKBELGETIPI");
                entity.Property(e => e.SELECTED).HasColumnName("SELECTED");
                entity.Property(e => e.MASRAF1).HasColumnName("MASRAF1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF2).HasColumnName("MASRAF2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF3).HasColumnName("MASRAF3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAF4).HasColumnName("MASRAF4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MASRAFKDV1).HasColumnName("MASRAFKDV1");
                entity.Property(e => e.MASRAFKDV2).HasColumnName("MASRAFKDV2");
                entity.Property(e => e.MASRAFKDV3).HasColumnName("MASRAFKDV3");
                entity.Property(e => e.MASRAFKDV4).HasColumnName("MASRAFKDV4");
                entity.Property(e => e.TAHSILATTUTARI).HasColumnName("TAHSILATTUTARI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.SATISSEKLI).HasColumnName("SATISSEKLI");
                entity.Property(e => e.ARATOPLAM).HasColumnName("ARATOPLAM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.ODEMEOPSIYONU).HasColumnName("ODEMEOPSIYONU");
                entity.Property(e => e.TEVKIFATORAN).HasColumnName("TEVKIFATORAN").HasColumnType("decimal(28,8)");
                entity.Property(e => e.STATUS).HasColumnName("STATUS");
                entity.Property(e => e.YURTDISI).HasColumnName("YURTDISI");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.CHECKAPATMA).HasColumnName("CHECKAPATMA");
                entity.Property(e => e.PESINFIRMAADI).HasColumnName("PESINFIRMAADI").HasMaxLength(200);
                entity.Property(e => e.PESINADRES).HasColumnName("PESINADRES").HasMaxLength(200);
                entity.Property(e => e.PESINVERGIDAIRESI).HasColumnName("PESINVERGIDAIRESI").HasMaxLength(100);
                entity.Property(e => e.PESINVERGINO).HasColumnName("PESINVERGINO").HasMaxLength(50);
                entity.Property(e => e.HAREKETDEPOSU).HasColumnName("HAREKETDEPOSU");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.EFATURA).HasColumnName("EFATURA");
                entity.Property(e => e.EFATURANO).HasColumnName("EFATURANO").HasMaxLength(50);
                entity.Property(e => e.EFATURAUUID).HasColumnName("EFATURAUUID").HasMaxLength(100);
                entity.Property(e => e.EFATURANUMBER).HasColumnName("EFATURANUMBER").HasMaxLength(50);
                entity.Property(e => e.EFATURASTATE).HasColumnName("EFATURASTATE");
                entity.Property(e => e.SENTSTATUS).HasColumnName("SENTSTATUS");
                entity.Property(e => e.EFATURAALIAS).HasColumnName("EFATURAALIAS").HasMaxLength(200);
                entity.Property(e => e.EFATURAACIKLAMA).HasColumnName("EFATURAACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.EKACIKLAMA).HasColumnName("EKACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.STOKHAREKETEYAZ).HasColumnName("STOKHAREKETEYAZ");
                entity.Property(e => e.CARIHAREKETEYAZ).HasColumnName("CARIHAREKETEYAZ");
                entity.Property(e => e.EFATURATIPI).HasColumnName("EFATURATIPI").HasMaxLength(50);
                entity.Property(e => e.EFATURAKODU).HasColumnName("EFATURAKODU").HasMaxLength(50);
                entity.Property(e => e.ETICARET).HasColumnName("ETICARET");
                entity.Property(e => e.IRSALIYELIFATURA).HasColumnName("IRSALIYELIFATURA");
                entity.Property(e => e.YAZARKASAFISI).HasColumnName("YAZARKASAFISI");
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
                entity.Property(e => e.RESPONSESTATUS).HasColumnName("RESPONSESTATUS");
                entity.Property(e => e.RESPONSECODE).HasColumnName("RESPONSECODE").HasMaxLength(50);
                entity.Property(e => e.RESPONSEMESSAGE).HasColumnName("RESPONSEMESSAGE").HasMaxLength(500);
                entity.Property(e => e.INTEGRATIONFOLDER).HasColumnName("IntegrationFolder");
                entity.Property(e => e.PESINMAIL).HasColumnName("PESINMAIL").HasMaxLength(100);
                entity.Property(e => e.YAZDIRILDI).HasColumnName("YAZDIRILDI");
            });

            modelBuilder.Entity<SatFatHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLSATFATHAREKET");
                entity.HasKey(e => e.Ind);

                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Detay).HasColumnName("DETAY");
                entity.Property(e => e.Selected).HasColumnName("SELECTED");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.StokNo).HasColumnName("STOKNO");
                entity.Property(e => e.MalinCinsi).HasColumnName("MALINCINSI").HasMaxLength(200);
                entity.Property(e => e.StokKodu).HasColumnName("STOKKODU").HasMaxLength(200);
                entity.Property(e => e.StokTipi).HasColumnName("STOKTIPI");
                entity.Property(e => e.Miktar).HasColumnName("MIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BirimMiktar).HasColumnName("BIRIMMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Birim).HasColumnName("BIRIM").HasMaxLength(5);
                entity.Property(e => e.BirimEx).HasColumnName("BIRIMEX");
                entity.Property(e => e.Kdv).HasColumnName("KDV");
                entity.Property(e => e.KdvTutari).HasColumnName("KDVTUTARI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk1).HasColumnName("ISK1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk2).HasColumnName("ISK2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk3).HasColumnName("ISK3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk4).HasColumnName("ISK4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.AFiyatı).HasColumnName("AFIYATI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Fiyati).HasColumnName("FIYATI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GercekToplam).HasColumnName("GERCEKTOPLAM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Depo).HasColumnName("DEPO");
                entity.Property(e => e.Personel).HasColumnName("PERSONEL");
                entity.Property(e => e.Pirim).HasColumnName("PIRIM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Opsiyon).HasColumnName("OPSIYON");
                entity.Property(e => e.Promosyon).HasColumnName("PROMOSYON");
                entity.Property(e => e.SatisKosulu).HasColumnName("SATISKOSULU");
                entity.Property(e => e.SeriMiktar).HasColumnName("SERIMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Envanter).HasColumnName("ENVANTER").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KarsiStokKodu).HasColumnName("KARSISTOKKODU").HasMaxLength(50);
                entity.Property(e => e.KarsiBarkod).HasColumnName("KARSIBARKOD").HasMaxLength(50);
                entity.Property(e => e.Termin).HasColumnName("TERMIN");
                entity.Property(e => e.Taksit).HasColumnName("TAKSIT");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Barkod).HasColumnName("BARKOD").HasMaxLength(50);
                entity.Property(e => e.Pesinat).HasColumnName("PESINAT").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Masraf).HasColumnName("MASRAF").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MasrafKdv).HasColumnName("MASRAFKDV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.PAciklama).HasColumnName("PACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.OIV).HasColumnName("OIV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Indirim).HasColumnName("INDIRIM").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OTV).HasColumnName("OTV").HasColumnType("decimal(28,8)");
                entity.Property(e => e.HurdaIndirimi).HasColumnName("HURDAINDIRIMI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GumrukVergisi).HasColumnName("GUMRUKVERGISI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.DigerVergiler).HasColumnName("DIGERVERGILER").HasColumnType("decimal(28,8)");
                entity.Property(e => e.MiktarStr).HasColumnName("MIKTARSTR").HasMaxLength(50);
                entity.Property(e => e.Gk).HasColumnName("GK");
                entity.Property(e => e.GrupMiktar).HasColumnName("GRUPMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TartilanMiktar).HasColumnName("TARTILANMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Mf).HasColumnName("MF").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK1).HasColumnName("ITSISK1").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK2).HasColumnName("ITSISK2").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK3).HasColumnName("ITSISK3").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ItSisK4).HasColumnName("ITSISK4").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OrjFiyat).HasColumnName("ORJFIYAT").HasColumnType("decimal(28,8)");
                entity.Property(e => e.GMiktar).HasColumnName("GMIKTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk5).HasColumnName("ISK5").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Isk6).HasColumnName("ISK6").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Uıd).HasColumnName("UID").HasMaxLength(60);
                entity.Property(e => e.OtvMaTrahi).HasColumnName("OTVMATRAHI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Kdv_ExMaTrahi).HasColumnName("KDV_EXMATRAHI").HasColumnType("decimal(28,8)");
                entity.Property(e => e.SatirNo).HasColumnName("SATIRNO");
                entity.Property(e => e.TevkiFatUyg).HasColumnName("TEVKIFATUYG");
                entity.Property(e => e.TevkiFatTutar).HasColumnName("TEVKIFATTUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.KampanyaAciklamasi).HasColumnName("KAMPANYAACIKLAMASI").HasMaxLength(250);
            });
        }
    }
}
