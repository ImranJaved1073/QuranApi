using QuranApi.Models;

namespace QuranApi.Interfaces
{
    public interface ISurahAyatService
    {
        Task<IEnumerable<Ayah>> GetAllAyatsAsync();
        Task<Ayah> GetAyatByIdAsync(int id);
        Task CreateAyatAsync(Ayah ayat);
        Task UpdateAyatAsync(Ayah ayat);
        Task DeleteAyatAsync(int id);
        Task CreateAyatsAsync(IEnumerable<Ayah> ayahs);
        Task<bool> AyatExistsAsync(int id);
        Task<IEnumerable<Ayah>> GetAyatsBySurahIdAsync(int surahId);
    }
}
