namespace QuranApi.Models
{
    public class SurahDetail
    {
        public Surah? Surah { get; set; }
        public IEnumerable<Ayah>? Ayahs { get; set; }
    }
}
