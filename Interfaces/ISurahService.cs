using QuranApi.Models;

namespace QuranApi.Interfaces
{
    public interface ISurahService
    {
        Task<IEnumerable<Surah>> GetAllSurahsAsync();
        Task<Surah> GetSurahByIdAsync(int id);
        Task CreateSurahAsync(Surah surah);
        Task UpdateSurahAsync(Surah surah);
        Task DeleteSurahAsync(int id);
    }
}
