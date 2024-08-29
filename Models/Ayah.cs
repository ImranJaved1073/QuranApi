using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranApi.Models
{
    [Table("Ayah")]
    public class Ayah
    {
        [Key]
        public int? AyaID { get; set; }

        public int? SuraID { get; set; }

        public int? AyaNo { get; set; }

        public string ArabicText { get; set; }

        public string FatehMuhammadJalandhrield { get; set; }

        public string MehmoodulHassan { get; set; }

        public string DrMohsinKhan { get; set; }

        public string MuftiTaqiUsmani { get; set; }

        public int? RakuID { get; set; }

        public int? PRakuID { get; set; }

        public int? ParaID { get; set; }
    }
}
