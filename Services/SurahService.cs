using Microsoft.EntityFrameworkCore;
using QuranApi.Interfaces;
using QuranApi.Models;

namespace QuranApi.Services
{
    public class SurahService : ISurahService
    {
        private readonly QuranDbContext _context;

        public SurahService(QuranDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Surah>> GetAllSurahsAsync()
        {
            return await _context.Surahs.ToListAsync();
        }

        public async Task<Surah> GetSurahByIdAsync(int id)
        {
            var surah = await _context.Surahs.FindAsync(id);
            if (surah == null)
                return new Surah();
            return surah;
        }

        public async Task CreateSurahAsync(Surah surah)
        {
            _context.Surahs.Add(surah);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSurahAsync(Surah surah)
        {
            _context.Surahs.Update(surah);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSurahAsync(int id)
        {
            var surah = await _context.Surahs.FindAsync(id);
            if (surah != null)
            {
                _context.Surahs.Remove(surah);
                await _context.SaveChangesAsync();
            }
        }
    }
}
