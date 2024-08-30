using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranApi.Models
{
    [Table("Para")]
    public class Para
    {
        [Key]
        public int ParaID { get; set; }

        public string? ArabicName { get; set; }

        public string? EnglishName { get; set; }

        public int TotalAyas { get; set; }

    }
}
