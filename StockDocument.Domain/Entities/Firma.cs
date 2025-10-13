using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Domain.Entities
{
    public class Firma
    {
        [Key]
        [Column("IND")]
        public int IND { get; set; }
        public string KOD { get; set; } = null!;
        public string? KISAAD { get; set; }
        public string? AD1 { get; set; }
        public string? AD2 { get; set; }
        public string? VDAIRESI { get; set; }
        public string? VNO { get; set; }
        public string? AKTIFDONEM { get; set; }
        public string? SEHIR { get; set; }
        public string? YETKILI { get; set; }
        public string? TCKIMLIKNO { get; set; }
        public string? WEBSITE { get; set; }
        public string? YETKILISOYADI { get; set; }
        public string? SERMAYE { get; set; }
        public string? SICILNO { get; set; }
        public string? GLNKODU { get; set; }
        public string? MAIL { get; set; }
    }
}
