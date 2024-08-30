using QuranApi.Models;

namespace QuranApi.Interfaces
{
    public interface IParaService
    {
        Task<IEnumerable<Para>> GetAllParasAsync();
        Task<Para> GetParaByIdAsync(int paraId);
        Task<Para> AddParaAsync(Para para);
        Task<Para> UpdateParaAsync(int paraId, Para para);
        Task DeleteParaAsync(int paraId);
    }
}
