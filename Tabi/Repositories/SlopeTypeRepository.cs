using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ISlopeTypeRepository
    {
        Task<IEnumerable<SlopeType>> GetSlopeTypes();
        Task<SlopeType> GetSlopeType(int id);
        Task<SlopeType> PostSlopeType(SlopeType slopeType);
        Task<SlopeType> PutSlopeType(int id, SlopeType slopeType);
        Task<SlopeType> DeleteSlopeType(int id);

    }

    public class SlopeTypeRepository : ISlopeTypeRepository
    {
        private readonly TabiContext _context;

        public SlopeTypeRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SlopeType>> GetSlopeTypes()
        {
            return await _context.SlopeTypes.ToListAsync();
        }

        public async Task<SlopeType> GetSlopeType(int id)
        {
            return await _context.SlopeTypes.FindAsync(id);
        }

        public async Task<SlopeType> PostSlopeType(SlopeType slopeType)
        {
            _context.SlopeTypes.Add(slopeType);
            await _context.SaveChangesAsync();
            return slopeType;
        }

        public async Task<SlopeType> PutSlopeType(int id, SlopeType slopeType)
        {
            _context.Entry(slopeType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return slopeType;
        }

        public async Task<SlopeType> DeleteSlopeType(int id)
        {
            var slopeType = await _context.SlopeTypes.FindAsync(id);
            if (slopeType == null)
            {
                return null;
            }

            _context.SlopeTypes.Remove(slopeType);
            await _context.SaveChangesAsync();
            return slopeType;
        }
    }
}
