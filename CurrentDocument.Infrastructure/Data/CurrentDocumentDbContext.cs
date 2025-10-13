using CurrentDocument.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Infrastructure.Data
{
    public class CurrentDocumentDbContext : DbContext
    {
        private readonly string _firmaInd;
        private readonly string _donemInd;

        public CurrentDocumentDbContext(DbContextOptions<CurrentDocumentDbContext> options, FirmaDonemContext firmaContext)
        : base(options)
        {
            _firmaInd = "101";
            _donemInd = "0003";
        }

        public DbSet<Firma> TBLFIRMA { get; set; }
        public DbSet<Donem> TBLDONEM { get; set; }

        public DbSet<CarGirBaslik> CarGirBasliklar { get; set; }
        public DbSet<CarGirHareket> CarGirHareketler { get; set; }
        public DbSet<CarCikBaslik> CarCikBasliklar { get; set; }
        public DbSet<CarCikHareket> CarCikHareketler { get; set; }
        public DbSet<CarGirDevirBaslik> CarGirDevirBasliklar { get; set; }
        public DbSet<CarGirDevirHareket> CarGirDevirHareketler { get; set; }
        public DbSet<CarCikDevirBaslik> CarCikDevirBasliklar { get; set; }
        public DbSet<CarCikDevirHareket> CarCikDevirHareketler { get; set; }

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

            modelBuilder.Entity<CarGirBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRBASLIK");
                entity.HasKey(e => e.IND);
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.AYLIKVADE).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KAPATMABELGESI).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.ACIKLAMA).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.HESAPKAPATMADISI).HasColumnName("HESAPKAPATMADISI");
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
            });

            modelBuilder.Entity<CarGirHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRHAREKET");                
                entity.HasKey(e => e.Ind);               
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500); 
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.VisaTahsilHareketNo).HasColumnName("VISATAHSILHAREKETNO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50); 
                entity.Property(e => e.GercekVade).HasColumnName("GERCEKVADE");
                entity.Property(e => e.AylikVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Aciklama2).HasColumnName("ACIKLAMA2").HasMaxLength(500); 
            });

            modelBuilder.Entity<CarCikBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKBASLIK");           
                entity.HasKey(e => e.IND);            
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.AYLIKVADE).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KAPATMABELGESI).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.ACIKLAMA).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.HESAPKAPATMADISI).HasColumnName("HESAPKAPATMADISI");
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
            });

            modelBuilder.Entity<CarCikHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKHAREKET");             
                entity.HasKey(e => e.Ind);               
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50);
                entity.Property(e => e.AylikVade).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.Aciklama2).HasColumnName("ACIKLAMA2").HasMaxLength(500);
            });

            modelBuilder.Entity<CarGirDevirBaslik>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRDEVIRBASLIK");
                entity.HasKey(e => e.IND);
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.AYLIKVADE).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KAPATMABELGESI).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.ACIKLAMA).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
            });

            modelBuilder.Entity<CarGirDevirHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARGIRDEVIRHAREKET");
                entity.HasKey(e => e.Ind);               
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500); 
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50); 
            });

            modelBuilder.Entity<CarCikDevirBaslik>(entity =>
            {                
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKDEVIRBASLIK");             
                entity.HasKey(e => e.IND);              
                entity.Property(e => e.IND).HasColumnName("IND");
                entity.Property(e => e.FIRMANO).HasColumnName("FIRMANO");
                entity.Property(e => e.BELGENO).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.TARIH).HasColumnName("TARIH");
                entity.Property(e => e.IADE).HasColumnName("IADE");
                entity.Property(e => e.AYLIKVADE).HasColumnName("AYLIKVADE").HasColumnType("decimal(28,8)");
                entity.Property(e => e.TUTAR).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.PARABIRIMI).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.KAPATMABELGESI).HasColumnName("KAPATMABELGESI");
                entity.Property(e => e.GIRIS).HasColumnName("GIRIS");
                entity.Property(e => e.KUR).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BELGETIPI).HasColumnName("BELGETIPI");
                entity.Property(e => e.IPTAL).HasColumnName("IPTAL");
                entity.Property(e => e.ENTEGRE).HasColumnName("ENTEGRE");
                entity.Property(e => e.USERNO).HasColumnName("USERNO");
                entity.Property(e => e.KDVISK).HasColumnName("KDVISK").HasColumnType("decimal(28,8)");
                entity.Property(e => e.OZELKOD1).HasColumnName("OZELKOD1").HasMaxLength(50);
                entity.Property(e => e.OZELKOD2).HasColumnName("OZELKOD2").HasMaxLength(50);
                entity.Property(e => e.ACIKLAMA).HasColumnName("ACIKLAMA").HasMaxLength(500);
                entity.Property(e => e.KONSOLIDE).HasColumnName("KONSOLIDE");
                entity.Property(e => e.MUHASEBELESMEYECEK).HasColumnName("MUHASEBELESMEYECEK");
                entity.Property(e => e.OZELKOD3).HasColumnName("OZELKOD3").HasMaxLength(50);
                entity.Property(e => e.OZELKOD4).HasColumnName("OZELKOD4").HasMaxLength(50);
                entity.Property(e => e.CREDATE).HasColumnName("CREDATE");
                entity.Property(e => e.KAYNAK).HasColumnName("KAYNAK");
                entity.Property(e => e.OZELKOD5).HasColumnName("OZELKOD5").HasMaxLength(50);
                entity.Property(e => e.OZELKOD6).HasColumnName("OZELKOD6").HasMaxLength(50);
                entity.Property(e => e.OZELKOD7).HasColumnName("OZELKOD7").HasMaxLength(50);
                entity.Property(e => e.OZELKOD8).HasColumnName("OZELKOD8").HasMaxLength(50);
                entity.Property(e => e.OZELKOD9).HasColumnName("OZELKOD9").HasMaxLength(50);
                entity.Property(e => e.UID).HasColumnName("UID").HasMaxLength(100);
            });

            modelBuilder.Entity<CarCikDevirHareket>(entity =>
            {
                entity.ToTable($"F0{_firmaInd}D{_donemInd}TBLCARCIKDEVIRHAREKET");               
                entity.HasKey(e => e.Ind);             
                entity.Property(e => e.Ind).HasColumnName("IND");
                entity.Property(e => e.Izahat).HasColumnName("IZAHAT");
                entity.Property(e => e.PortNo).HasColumnName("PORTNO");
                entity.Property(e => e.EvrakNo).HasColumnName("EVRAKNO");
                entity.Property(e => e.Aciklama).HasColumnName("ACIKLAMA").HasMaxLength(500); 
                entity.Property(e => e.Vade).HasColumnName("VADE");
                entity.Property(e => e.Tutar).HasColumnName("TUTAR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.ParaBirimi).HasColumnName("PARABIRIMI").HasMaxLength(10);
                entity.Property(e => e.BelgeNo).HasColumnName("BELGENO").HasMaxLength(50);
                entity.Property(e => e.BelgeLink).HasColumnName("BELGELINK");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Kur).HasColumnName("KUR").HasColumnType("decimal(28,8)");
                entity.Property(e => e.BankaNo).HasColumnName("BANKANO");
                entity.Property(e => e.FirmaNo).HasColumnName("FIRMANO");
                entity.Property(e => e.MuhHesapKodu).HasColumnName("MUHHESAPKODU").HasMaxLength(50); 
            });
        }
    }
}
