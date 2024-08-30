namespace QuranApi.Models
{
    public class ParaDetail
    {
        public Para? Para { get; set; }
        public IEnumerable<Ayah>? Ayahs { get; set; }
    }
}
