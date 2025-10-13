using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Shared.Dtos
{
    public class CarGirBaslikDto
    {
        public int IND { get; set; }
        public int? FIRMANO { get; set; }
        public string? BELGENO { get; set; }
        public DateTime? TARIH { get; set; }
        public bool? IADE { get; set; }
        public decimal? AYLIKVADE { get; set; }
        public decimal? TUTAR { get; set; }
        public string? PARABIRIMI { get; set; }
        public int? KAPATMABELGESI { get; set; }
        public bool? GIRIS { get; set; }
        public decimal? KUR { get; set; }
        public CurrentType? BELGETIPI { get; set; }
        public bool? IPTAL { get; set; }
        public int? ENTEGRE { get; set; }
        public int? USERNO { get; set; }
        public decimal? KDVISK { get; set; }
        public string? ACIKLAMA { get; set; }
        public int? KONSOLIDE { get; set; }
        public bool? MUHASEBELESMEYECEK { get; set; }    
        public DateTime? CREDATE { get; set; }

        public CarGirBaslikDto()
        {

        }

        public CarGirBaslikDto(CarGirBaslik entity)
        {
            IND = entity.IND;
            FIRMANO = entity.FIRMANO;
            TUTAR = entity.TUTAR;
            BELGENO = entity.BELGENO;
            TARIH = entity.TARIH;
            BELGETIPI = (CurrentType?)entity.BELGETIPI;
        }
    }
}
