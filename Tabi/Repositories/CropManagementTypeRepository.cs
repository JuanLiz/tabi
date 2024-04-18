using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropManagementTypeRepository
    {
        Task<IEnumerable<CropManagementType>> GetCropManagementTypes();
        Task<CropManagementType?> GetCropManagementType(int id);
        Task<CropManagementType> CreateCropManagementType(CropManagementType cropManagementType);
        Task<CropManagementType> UpdateCropManagementType(CropManagementType cropManagementType);
        Task<CropManagementType?> DeleteCropManagementType(int id);

    }

    public class CropManagementTypeRepository(TabiContext db) : ICropManagementTypeRepository
    {
        public async Task<IEnumerable<CropManagementType>> GetCropManagementTypes()
        {
            return await db.CropManagementTypes.ToListAsync();
        }

        public async Task<CropManagementType?> GetCropManagementType(int id)
        {
            return await db.CropManagementTypes.FindAsync(id);
        }

        public async Task<CropManagementType> CreateCropManagementType(CropManagementType cropManagementType)
        {
            db.CropManagementTypes.Add(cropManagementType);
            await db.SaveChangesAsync();
            return cropManagementType;
        }

        public async Task<CropManagementType> UpdateCropManagementType(CropManagementType cropManagementType)
        {
            db.Entry(cropManagementType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropManagementType;
        }

        public async Task<CropManagementType?> DeleteCropManagementType(int id)
        {
            CropManagementType? cropManagementType = await db.CropManagementTypes.FindAsync(id);
            if (cropManagementType == null) return cropManagementType;
            cropManagementType.IsActive = false;
            db.Entry(cropManagementType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropManagementType;
        }
    }
}
