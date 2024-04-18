using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ISlopeTypeRepository
    {
        Task<IEnumerable<SlopeType>> GetSlopeTypes();
        Task<SlopeType?> GetSlopeType(int id);
        Task<SlopeType> CreateSlopeType(SlopeType slopeType);
        Task<SlopeType> UpdateSlopeType(SlopeType slopeType);
        Task<SlopeType?> DeleteSlopeType(int id);

    }

    public class SlopeTypeRepository(TabiContext db) : ISlopeTypeRepository
    {
        public async Task<IEnumerable<SlopeType>> GetSlopeTypes()
        {
            return await db.SlopeTypes.ToListAsync();
        }

        public async Task<SlopeType?> GetSlopeType(int id)
        {
            return await db.SlopeTypes.FindAsync(id);
        }

        public async Task<SlopeType> CreateSlopeType(SlopeType slopeType)
        {
            db.SlopeTypes.Add(slopeType);
            await db.SaveChangesAsync();
            return slopeType;
        }

        public async Task<SlopeType> UpdateSlopeType(SlopeType slopeType)
        {
            db.Entry(slopeType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return slopeType;
        }

        public async Task<SlopeType?> DeleteSlopeType(int id)
        {
            SlopeType? slopeType = await db.SlopeTypes.FindAsync(id);
            if (slopeType == null) return slopeType;
            slopeType.IsActive = false;
            db.Entry(slopeType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return slopeType;
        }
    }
}
