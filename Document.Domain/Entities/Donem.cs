using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Domain.Entities
{
    [Table("TBLDONEM")]
    public class Donem
    {
   
        public int IND { get; set; }        // PK

        public int FIND { get; set; }       // Firma kodu (FK gibi)

        public short DONEM { get; set; }
    }
}
