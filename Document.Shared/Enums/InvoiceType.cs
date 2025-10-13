using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Shared.Enums
{
    public enum InvoiceType
    {
        [Description("Alış Faturası")]
        AlFat = 20,

        [Description("Satış Faturası")]
        SatFat = 21,

        [Description("Alıştan İade")]
        AlIade = 22,

        [Description("Satıştan İade")]
        SatIade = 23,

        [Description("Proforma Faturası")]
        ProformaFat = 24,

        [Description("Peşin Satış Faturası")]
        PeşSatFat = 25,

        [Description("Peşin Alış Faturası")]
        PeşAlFat = 86,

        [Description("Peşin Satıştan İade")]
        PeşSatIade = 87,

        [Description("Peşin Alıştan İade")]
        PeşAlIade = 88,

        [Description("POS Faturası")]
        PosFat = 89,

        [Description("POS Faturası 2")]
        PosFat2 = 100,

        [Description("POS Fiş")]
        PosFiş = 101,

        [Description("Arc Alıştan İade Faturası")]
        ArcAlIadeFat = 109,

        [Description("Arc Satış Faturası İade")]
        ArcSatFatIade = 121,

        [Description("IMF Alış Faturası")]
        IMFAlFat = 142,

        [Description("IMF Satış Faturası")]
        IMFSatFat = 143,

        [Description("IMF Alıştan İade Faturası")]
        IMFAlFatIade = 144,

        [Description("IMF Satıştan İade Faturası")]
        IMFSatFatIade = 145
    }
}
