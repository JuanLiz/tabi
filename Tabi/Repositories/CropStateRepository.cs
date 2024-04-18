using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropStateRepository
    {
        Task<IEnumerable<CropState>> GetCropStates();
        Task<CropState?> GetCropState(int id);
        Task<CropState> CreateCropState(CropState cropState);
        Task<CropState> UpdateCropState(CropState cropState);
        Task<CropState?> DeleteCropState(int id);

    }

    public class CropStateRepository(TabiContext db) : ICropStateRepository
    {
        public async Task<IEnumerable<CropState>> GetCropStates()
        {
            return await db.CropStates.ToListAsync();
        }

        public async Task<CropState?> GetCropState(int id)
        {
            return await db.CropStates.FindAsync(id);
        }

        public async Task<CropState> CreateCropState(CropState cropState)
        {
            db.CropStates.Add(cropState);
            await db.SaveChangesAsync();
            return cropState;
        }

        public async Task<CropState> UpdateCropState(CropState cropState)
        {
            db.Entry(cropState).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropState;
        }

        public async Task<CropState?> DeleteCropState(int id)
        {
            CropState? cropState = await db.CropStates.FindAsync(id);
            if (cropState == null) return cropState;
            cropState.IsActive = false;
            db.Entry(cropState).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropState;
        }
    }
}
