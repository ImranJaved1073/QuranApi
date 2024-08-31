using Microsoft.EntityFrameworkCore;
using QuranApi.Models;
using QuranApi.Interfaces;

namespace QuranApi.Services
{
    public class SurahAyatService : ISurahAyatService
    {
        private readonly QuranDbContext _context;

        public SurahAyatService(QuranDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ayah>> GetAllAyatsAsync()
        {
            return await _context.Ayahs.ToListAsync();
        }

        public async Task<Ayah> GetAyatByIdAsync(int id)
        {
            var ayat = await _context.Ayahs.FindAsync(id);
            if (ayat == null) {
                return null!;
            }
            return ayat;
        }

        public async Task CreateAyatAsync(Ayah ayah)
        {
            _context.Ayahs.Add(ayah);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAyatAsync(Ayah ayah)
        {
            _context.Entry(ayah).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAyatAsync(int id)
        {
            var surah = await _context.Ayahs.FindAsync(id);
            if (surah != null)
            {
                _context.Ayahs.Remove(surah);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ayah>> GetAyatsBySurahIdAsync(int surahId)
        {
            return await _context.Ayahs
                .Where(a => a.SuraID == surahId)
                .OrderBy(x => x.AyaNo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ayah>> GetAyatsByParaIdAsync(int paraId)
        {
            return await _context.Ayahs
                .Where(a => a.ParaID == paraId)
                .OrderBy(x => x.pAyatID)
                .ToListAsync();
        }

        public async Task CreateAyatsAsync(IEnumerable<Ayah> ayahs)
        {
            _context.Ayahs.AddRange(ayahs);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AyatExistsAsync(int id)
        {
            return await _context.Ayahs.AnyAsync(e => e.AyaID == id);
        }
    }
}
