using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Shared.Enums
{
    public enum StockType
    {
        [Description("Stok Giriş Fişi")]
        StkGirişFişi = 32,

        [Description("Stok Çıkış Fişi")]
        StkÇıkışFişi = 33
    }
}
