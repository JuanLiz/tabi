using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropRepository
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop?> GetCrop(int id);
        Task<Crop> CreateCrop(Crop crop);
        Task<Crop> UpdateCrop(Crop crop);
        Task<Crop?> DeleteCrop(int id);

    }

    public class CropRepository(TabiContext db) : ICropRepository
    {
        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await db.Crops.ToListAsync();
        }

        public async Task<Crop?> GetCrop(int id)
        {
            return await db.Crops.FindAsync(id);
        }

        // TODO Class creation
        public async Task<Crop> CreateCrop(Crop crop)
        {
            db.Crops.Add(crop);
            await db.SaveChangesAsync();
            return crop;
        }

        public async Task<Crop> UpdateCrop(Crop crop)
        {
            db.Entry(crop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return crop;
        }

        public async Task<Crop?> DeleteCrop(int id)
        {
            Crop? crop = await db.Crops.FindAsync(id);
            if (crop == null) return crop;
            crop.IsActive = false;
            db.Entry(crop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return crop;
        }
    }
}
