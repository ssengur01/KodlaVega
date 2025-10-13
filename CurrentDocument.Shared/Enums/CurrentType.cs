using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Shared.Enums
{
    public enum CurrentType
    {
        [Description("Cari Çıkış Faturası")]
        CarÇık = 11,

        [Description("Cari Giriş Faturası")]
        CarGir = 13,

        [Description("Cari Giriş Devir Faturası")]
        CarGirDevir = 18,

        [Description("Cari Çıkış Devir Faturası")]
        CarCikDevir = 19,
    }
}
