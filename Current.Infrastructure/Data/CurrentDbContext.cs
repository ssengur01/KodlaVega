using Microsoft.EntityFrameworkCore;
using Current.Domain.Entities;

namespace Current.Infrastructure.Data
{
    public class CurrentDbContext : DbContext
    {
        private readonly string _firmaInd;
        private readonly string _donemInd;

        public CurrentDbContext(DbContextOptions<CurrentDbContext> options, FirmaDonemContext firmaContext)
        : base(options)
        {
            _firmaInd = "101";
            _donemInd = "0003";
        }

        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Firma> TBLFIRMA { get; set; }
        public DbSet<Donem> TBLDONEM { get; set; }
        public DbSet<CariHareketleri> CariHareketleri { get; set; }
        public DbSet<CariCikisBaslik> CariCikisBasliklar { get; set; }
        public DbSet<CariCikisHareket> CariCikisHareketler { get; set; }
        public DbSet<CariGirisBaslik> CariGirisBasliklar { get; set; }
        public DbSet<CariGirisHareket> CariGirisHareketler { get; set; }
        public DbSet<CariGenelHareket> CariGenelHareketler { get; set; }
        public string GetIzahatFromFunction(int izahat)
        {
            // EF Core tarafından SQL’e çevrileceği için gövde boş olabilir
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .HasDbFunction(typeof(CurrentDbContext)
            .GetMethod(nameof(GetIzahatFromFunction), new[] { typeof(int) }))
            .HasName("IZAHATTOSTR") // SQL’deki function adı
            .HasSchema("dbo");



            modelBuilder.Entity<Firma>().ToTable("TBLFIRMA");
            modelBuilder.Entity<Firma>().HasKey(f => f.IND);

            modelBuilder.Entity<Donem>(entity =>
            {
                entity.ToTable("TBLDONEM");
                entity.HasKey(d => d.IND);

                entity.Property(d => d.FIND).HasColumnName("FIND");
                entity.Property(d => d.DONEM).HasColumnName("DONEM");
            });

            modelBuilder.Entity<Cari>(entity =>
            {
                entity.HasKey(e => e.Ind);
                entity.ToTable($"F0{_firmaInd}TBLCARI");
//              entity.HasKey(e => e.Ind).HasName("PK_TBLCARI");
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.FirmaKodu).HasColumnName("FIRMAKODU").HasMaxLength(50);
                entity.Property(e => e.FirmaAdi).HasColumnName("FIRMAADI").HasMaxLength(255);
                entity.Property(e => e.Yetkili).HasColumnName("YETKILI").HasMaxLength(100);
                entity.Property(e => e.VergiDairesi).HasColumnName("VERGIDAIRESI").HasMaxLength(100);
                entity.Property(e => e.VergiNo).HasColumnName("VERGINO").HasMaxLength(20);
                entity.Property(e => e.RiskLimiti).HasColumnName("RISKLIMITI").HasColumnType("decimal(18,2)");
                entity.Property(e => e.KayitTarihi).HasColumnName("KAYITTARIHI");
                entity.Property(e => e.KrediLimiti).HasColumnName("KREDILIMITI").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Iskonto).HasColumnName("ISKONTO").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Ayvilade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Opsiyon).HasColumnName("OPSIYON");
                entity.Property(e => e.FirmaTipi).HasColumnName("FIRMATIPI");
                entity.Property(e => e.Statu).HasColumnName("STATU");
                entity.Property(e => e.OdemeBayKesi).HasColumnName("ODEMEBAKIYESI").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Bakiye).HasColumnName("BAKIYE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Kod1).HasColumnName("KOD1").HasMaxLength(50);
                entity.Property(e => e.Kod2).HasColumnName("KOD2").HasMaxLength(50);
                entity.Property(e => e.Kod3).HasColumnName("KOD3").HasMaxLength(50);
                entity.Property(e => e.Kod4).HasColumnName("KOD4").HasMaxLength(50);
                entity.Property(e => e.Kod5).HasColumnName("KOD5").HasMaxLength(50);
                entity.Property(e => e.Soyadi).HasColumnName("SOYADI").HasMaxLength(100);
                entity.Property(e => e.Adi).HasColumnName("ADI").HasMaxLength(100);
                entity.Property(e => e.Deleted).HasColumnName("DELETED");
                entity.Property(e => e.Istihbarat).HasColumnName("ISTIHBARAT").HasMaxLength(500);
                entity.Property(e => e.Unvan).HasColumnName("UNVAN").HasMaxLength(255);
                entity.Property(e => e.Sektor).HasColumnName("SEKTOR").HasMaxLength(100);
                entity.Property(e => e.Marka).HasColumnName("MARKA").HasMaxLength(100);
                entity.Property(e => e.Url).HasColumnName("URL").HasMaxLength(255);
                entity.Property(e => e.Telefon1).HasColumnName("TELEFON1").HasMaxLength(20);
                entity.Property(e => e.Telefon2).HasColumnName("TELEFON2").HasMaxLength(20);
                entity.Property(e => e.Telefon3).HasColumnName("TELEFON3").HasMaxLength(20);
                entity.Property(e => e.Faks).HasColumnName("FAKS").HasMaxLength(20);
                entity.Property(e => e.Modem).HasColumnName("MODEM").HasMaxLength(20);
                entity.Property(e => e.AdresPosta).HasColumnName("ADRESPOSTA").HasMaxLength(500);
                entity.Property(e => e.AdresFatura).HasColumnName("ADRESFATURA").HasMaxLength(500);
                entity.Property(e => e.AdresSevk).HasColumnName("ADRESSEVK").HasMaxLength(500);
                entity.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(100);
                entity.Property(e => e.Web).HasColumnName("YURL").HasMaxLength(255);
                entity.Property(e => e.YetkiliMail).HasColumnName("YEMAIL").HasMaxLength(100);
                entity.Property(e => e.Ydahil).HasColumnName("YDAHILI").HasMaxLength(100);
                entity.Property(e => e.YtelFon1).HasColumnName("YTELEFON1").HasMaxLength(20);
                entity.Property(e => e.YtelFon2).HasColumnName("YTELEFON2").HasMaxLength(20);
                entity.Property(e => e.Ygsm).HasColumnName("YGSM").HasMaxLength(20);
                entity.Property(e => e.Ymodem).HasColumnName("YMODEM").HasMaxLength(20);
                entity.Property(e => e.Kefil1).HasColumnName("KEFIL1").HasMaxLength(100);
                entity.Property(e => e.Kefil1Adres).HasColumnName("KEFILADRES1").HasMaxLength(500);
                entity.Property(e => e.Kefil1Telefon).HasColumnName("KEFIL1TELEFON").HasMaxLength(20);
                entity.Property(e => e.Kefil2).HasColumnName("KEFIL2").HasMaxLength(100);
                entity.Property(e => e.Kefil2Adres).HasColumnName("KEFILADRES2").HasMaxLength(500);
                entity.Property(e => e.Kefil2Telefon).HasColumnName("KEFIL2TELEFON").HasMaxLength(20);
                entity.Property(e => e.GecikmeFaizi).HasColumnName("GECIKMEFAIZI").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Resim).HasColumnName("RESIM");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.PersonelNo).HasColumnName("PERSONELNO");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.SatisYapilmasin).HasColumnName("SATISYAPILMASIN");
                entity.Property(e => e.Depo).HasColumnName("DEPO");
                entity.Property(e => e.Zimmet).HasColumnName("ZIMFIYAT");
                entity.Property(e => e.TahsilatYapilmasin).HasColumnName("TAHSILATYAPILMASIN");
                entity.Property(e => e.TckimlikNo).HasColumnName("KEFIL1TCKIMLIKNO").HasMaxLength(11);
                entity.Property(e => e.VergiKimlikNo).HasColumnName("KEFIL2TCKIMLIKNO").HasMaxLength(20);
                entity.Property(e => e.BagkurCalismasin).HasColumnName("BAGKURCALISMASIN");
                entity.Property(e => e.FirmaTakipKodu).HasColumnName("FIRMATAKIPKODU").HasMaxLength(50);
                entity.Property(e => e.Kefil1TakipKodu).HasColumnName("KEFIL1TAKIPKODU").HasMaxLength(50);
                entity.Property(e => e.Kefil2TakipKodu).HasColumnName("KEFIL2TAKIPKODU").HasMaxLength(50);
                entity.Property(e => e.OdemeSekli).HasColumnName("ODEMESEKLI");
                entity.Property(e => e.Prim).HasColumnName("PRIM").HasColumnType("decimal(18,2)");
                entity.Property(e => e.IadeFaturaSiKesilmesin).HasColumnName("IADEFATURASIKESILMESIN");
                entity.Property(e => e.DepoInd).HasColumnName("DEPOIND");
                entity.Property(e => e.Il).HasColumnName("IL").HasMaxLength(50);
                entity.Property(e => e.Sehir).HasColumnName("SEHIR").HasMaxLength(50);
                entity.Property(e => e.EfaturaKullanicisi).HasColumnName("EFATURAKULLANICISI");
                entity.Property(e => e.EfaturaSenaryo).HasColumnName("EFATURASENARYO");
                entity.Property(e => e.KrediLimitiKontrol).HasColumnName("KREDILIMITIKONTROL");
                entity.Property(e => e.Alias).HasColumnName("ALIAS").HasMaxLength(100);
                entity.Property(e => e.Sermaye).HasColumnName("SERMAYE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.SicilNo).HasColumnName("SICILNO").HasMaxLength(50);
                entity.Property(e => e.Eticaret).HasColumnName("ETICARET");
                entity.Property(e => e.IseGirisTarihi).HasColumnName("ISEGIRISTARIHI");
                entity.Property(e => e.IstenCikisTarihi).HasColumnName("ISTENCIKISTARIHI");
                entity.Property(e => e.OdemeYapilmasin).HasColumnName("ODEMEYAPILMASIN");
                entity.Property(e => e.GrupKodu).HasColumnName("GRUPKODU").HasMaxLength(50);
                entity.Property(e => e.NaceKodu).HasColumnName("NACEKODU").HasMaxLength(20);
                entity.Property(e => e.HedefCiro).HasColumnName("HEDEFCIRO").HasColumnType("decimal(18,2)");
                entity.Property(e => e.SmsGonder).HasColumnName("SMSGONDER");
                entity.Property(e => e.EmailGonder).HasColumnName("EMAILGONDER");
                entity.Property(e => e.EarsivTeslimTipi).HasColumnName("EARSIVTESLIMTIPI");
                entity.Property(e => e.Kod6).HasColumnName("KOD6").HasMaxLength(50);
                entity.Property(e => e.Kod7).HasColumnName("KOD7").HasMaxLength(50);
                entity.Property(e => e.IsletmeTuru).HasColumnName("ISLETMETURU");
                entity.Property(e => e.GlnKodu).HasColumnName("GLNKODU").HasMaxLength(50);
                entity.Property(e => e.SubeAdi).HasColumnName("SUBEADI").HasMaxLength(100);
                entity.Property(e => e.Uid).HasColumnName("UID").HasMaxLength(50);
                entity.Property(e => e.AlisYapilmasin).HasColumnName("ALISYAPILMASIN");
                entity.Property(e => e.SiparisYapilmasin).HasColumnName("SIPARISYAPILMASIN");
                entity.Property(e => e.Eirsaliye).HasColumnName("EIRSALIYE");
                entity.Property(e => e.EirsaliyeAlis).HasColumnName("EIRSALIYEALIAS").HasMaxLength(50);
                entity.Property(e => e.KdvMuafiyati).HasColumnName("KDVMUAFIYATI");
                entity.Property(e => e.CariPozisyon).HasColumnName("CARIPOZISYON");
                entity.Property(e => e.KurTipi).HasColumnName("KURTIPI");
                entity.Property(e => e.AliasGuncellenmesin).HasColumnName("ALIASGUNCELLENMESIN");
                entity.Property(e => e.UtsKurumNo).HasColumnName("UTSKURUMNO").HasMaxLength(50);
                entity.Property(e => e.GuncellemeTarihi).HasColumnName("GUNCELLEMETARIHI");
            });


            // CariCikisBaslik entity configuration
            modelBuilder.Entity<CariCikisBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKBASLIK");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Iade).HasColumnName("IADE");
                entity.Property(e => e.AylıkVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(18,2)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KapatmaBelgesi).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.Giris).HasColumnName("GIRIS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.BelgeTipi).HasColumnName("BELGETIPI");
                entity.Property(e => e.Iptal).HasColumnName("IPTAL");
                entity.Property(e => e.Entegre).HasColumnName("ENTEGRE");
                entity.Property(e => e.UserNo).HasColumnName("USERNO");
                entity.Property(e => e.KdvIsk).HasColumnName("KDVISK").HasColumnType("decimal(18,2)");
                entity.Property(e => e.OzelKod1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OzelKod2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KonsolIde).HasColumnName("KONSOLIDE");
                entity.Property(e => e.Muhasebelesmeyecek).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OzelKod3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OzelKod4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.Credate).HasColumnName("CREDATE");
                entity.Property(e => e.Kaynak).HasColumnName("KAYNAK");
                entity.Property(e => e.OzelKod5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OzelKod6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OzelKod7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OzelKod8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.HesapKapatmaDisi).HasColumnName("HESAPKAPATMADISI");
                entity.Property(e => e.OzelKod9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.Uıd).HasColumnName("UID").HasMaxLength(50);
            });

            // CariCikisHareket entity configuration
            modelBuilder.Entity<CariCikisHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKHAREKET");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(18,2)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50);
                entity.Property(e => e.AylıkVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Aciklama2).HasColumnName("ACIKLAMA2").HasMaxLength(500);
            });

            // CariGenelHareket entity configuration
            modelBuilder.Entity<CariGenelHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARIGENELHAREKET");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.BelgeInd).HasColumnName("BELGEIND");
                entity.Property(e => e.IslemInd).HasColumnName("ISLEMIND");
                entity.Property(e => e.BelgeIzahat).HasColumnName("BELGEIZAHAT");
                entity.Property(e => e.IslemIzahat).HasColumnName("ISLEMIZAHAT");
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Borc).HasColumnName("BORC").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Alacak).HasColumnName("ALACAK").HasColumnType("decimal(18,2)");
                entity.Property(e => e.AylıkVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.IslemNo).HasColumnName("ISLEMNO").HasMaxLength(50);
                entity.Property(e => e.Converted).HasColumnName("CONVERTED");
                entity.Property(e => e.Iptal).HasColumnName("IPTAL");
                entity.Property(e => e.SıralamaTarihi).HasColumnName("SIRALAMATARIHI");
                entity.Property(e => e.TahsilLink).HasColumnName("TAHSILLINK");
                entity.Property(e => e.GecikmeHesapla).HasColumnName("GECIKMEHESAPLA");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.BaslikParaBirimi).HasColumnName("BASLIKPARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BaslikKuru).HasColumnName("BASLIKKURU").HasColumnType("decimal(18,4)");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.SıralamaTarihiEx).HasColumnName("SIRALAMATARIHIEX").HasColumnType("decimal(18,2)");
            });

            // CariGirisBaslik entity configuration
            modelBuilder.Entity<CariGirisBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRBASLIK");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Iade).HasColumnName("IADE");
                entity.Property(e => e.AylikVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(18,2)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KapatmaBelgesi).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.Giris).HasColumnName("GIRIS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.BelgeTipi).HasColumnName("BELGETIPI");
                entity.Property(e => e.Iptal).HasColumnName("IPTAL");
                entity.Property(e => e.Entegre).HasColumnName("ENTEGRE");
                entity.Property(e => e.UserNo).HasColumnName("USERNO");
                entity.Property(e => e.KdvIsk).HasColumnName("KDVISK").HasColumnType("decimal(18,2)");
                entity.Property(e => e.OzelKod1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OzelKod2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KonsolIde).HasColumnName("KONSOLIDE");
                entity.Property(e => e.Muhasebelesmeyecek).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OzelKod3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OzelKod4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.Credate).HasColumnName("CREDATE");
                entity.Property(e => e.Kaynak).HasColumnName("KAYNAK");
                entity.Property(e => e.OzelKod5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OzelKod6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OzelKod7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OzelKod8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.HesapKapatmaDisi).HasColumnName("HESAPKAPATMADISI");
                entity.Property(e => e.OzelKod9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.Uıd).HasColumnName("UID").HasMaxLength(50);
            });

            // CariGirisHareket entity configuration
            modelBuilder.Entity<CariGirisHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRHAREKET");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(18,2)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.VisaTahsilHareketNo).HasColumnName("VISATAHSILHAREKETNO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50);
                entity.Property(e => e.GercekVade).HasColumnName("GERCEKVADE");
                entity.Property(e => e.AylikVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Aciklama2).HasColumnName("ACIKLAMA2").HasMaxLength(500);
            });

            // CariHareketleri entity configuration
            modelBuilder.Entity<CariHareketleri>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARIHAREKETLERI");
                // entity.HasKey(e => e.Ind).HasName("PK_TBLCARIHAREKETLERI");
                entity.HasKey(e => e.Ind);
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.Tarih).HasColumnName("TARIH");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT").HasMaxLength(500);
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO").HasMaxLength(50);
                entity.Property(e => e.Borc).HasColumnName("BORC").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Alacak).HasColumnName("ALACAK").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Bakiye).HasColumnName("BAKIYE").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Ln).HasColumnName("LN");
                entity.Property(e => e.Iade).HasColumnName("IADE");
                entity.Property(e => e.Ln2).HasColumnName("LN2");
                entity.Property(e => e.ConvNum).HasColumnName("CONVNUM");
                entity.Property(e => e.ConvStyle).HasColumnName("CONVSTYLE");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(18,4)");
                entity.Property(e => e.OdemeTarihi).HasColumnName("ODEMETARIHI");
                entity.Property(e => e.IslemTarihi).HasColumnName("ISLEMTARIHI");
                entity.Property(e => e.SiralamaTarihi).HasColumnName("SIRALAMATARIHI");
                entity.Property(e => e.OzelKod).HasColumnName("OZELKOD").HasMaxLength(50);
                entity.Property(e => e.SiralamaTarihiEx).HasColumnName("SIRALAMATARIHIEX").HasColumnType("decimal(18,2)");              
            });   
        }
    }
}