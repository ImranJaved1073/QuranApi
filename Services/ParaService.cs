using Microsoft.EntityFrameworkCore;
using QuranApi.Interfaces;
using QuranApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuranApi.Services
{
    public class ParaService : IParaService
    {
        private readonly QuranDbContext _context;

        public ParaService(QuranDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Para>> GetAllParasAsync()
        {
            return await _context.Paras.ToListAsync();
        }

        public async Task<Para> GetParaByIdAsync(int paraId)
        {
            var para = await _context.Paras.FindAsync(paraId);
            if (para == null)
            {
                return null!;
            }
            return para;
        }

        public async Task<Para> AddParaAsync(Para para)
        {
            _context.Paras.Add(para);
            await _context.SaveChangesAsync();
            return para;
        }

        public async Task<Para> UpdateParaAsync(int paraId, Para para)
        {
            var existingPara = await _context.Paras.FindAsync(paraId);
            if (existingPara == null)
            {
                return null!;
            }

            existingPara.ArabicName = para.ArabicName;
            existingPara.EnglishName = para.EnglishName;
            existingPara.TotalAyas = para.TotalAyas;

            _context.Paras.Update(existingPara);
            await _context.SaveChangesAsync();

            return existingPara;
        }

        public async Task DeleteParaAsync(int paraId)
        {
            var para = await _context.Paras.FindAsync(paraId);
            if (para != null)
            {
                _context.Paras.Remove(para);
                await _context.SaveChangesAsync();
            }
        }
    }
}
