using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuranApi.Models
{
    [Table("Surah")]
    public class Surah
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; }
        public int NumberOfAyahs { get; set; }
        public string RevelationType { get; set; }
    }
}
