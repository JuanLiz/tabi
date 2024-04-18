using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropTypeRepository
    {
        Task<IEnumerable<CropType>> GetCropTypes();
        Task<CropType?> GetCropType(int id);
        Task<CropType> CreateCropType(CropType cropType);
        Task<CropType> UpdateCropType(CropType cropType);
        Task<CropType?> DeleteCropType(int id);

    }

    public class CropTypeRepository(TabiContext db) : ICropTypeRepository
    {
        public async Task<IEnumerable<CropType>> GetCropTypes()
        {
            return await db.CropTypes.ToListAsync();
        }

        public async Task<CropType?> GetCropType(int id)
        {
            return await db.CropTypes.FindAsync(id);
        }

        public async Task<CropType> CreateCropType(CropType cropType)
        {
            db.CropTypes.Add(cropType);
            await db.SaveChangesAsync();
            return cropType;
        }

        public async Task<CropType> UpdateCropType(CropType cropType)
        {
            db.Entry(cropType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropType;
        }

        public async Task<CropType?> DeleteCropType(int id)
        {
            CropType? cropType = await db.CropTypes.FindAsync(id);
            if (cropType == null) return cropType;
            cropType.IsActive = false;
            db.Entry(cropType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropType;
        }
    }
}
