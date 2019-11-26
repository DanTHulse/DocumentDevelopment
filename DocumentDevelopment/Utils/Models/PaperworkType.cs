using System.Collections.Generic;

namespace DocumentDevelopment.Utils.Models
{
    public enum PaperworkType
    {
        SolidFuelServicing = 1,
        ChimneySweeping = 2,
        Solar = 3,
        ASHP = 4,
        Unvented = 5,
        CD10T = 6,
        CD11 = 7,
        CD12 = 8,
        TI133D = 9,

        All = 10,
        AllSoildFuel = 11,
        AllOil = 12,
        AllOther = 13,
    }

    public static class DefaultTypes
    {
        public static List<PaperworkType> All => new List<PaperworkType>
        {
            PaperworkType.All,
            PaperworkType.AllOil,
            PaperworkType.AllOther,
            PaperworkType.AllSoildFuel,
        };

        public static List<PaperworkType> AllSolidFuel => new List<PaperworkType>
        {
            PaperworkType.SolidFuelServicing,
            PaperworkType.ChimneySweeping,
        };

        public static List<PaperworkType> AllOil => new List<PaperworkType>
        {
            PaperworkType.CD10T,
            PaperworkType.CD11,
            PaperworkType.CD12,
            PaperworkType.TI133D,
        };

        public static List<PaperworkType> AllOther => new List<PaperworkType>
        {
            PaperworkType.Solar,
            PaperworkType.Unvented,
            PaperworkType.ASHP,
        };
    }
}
