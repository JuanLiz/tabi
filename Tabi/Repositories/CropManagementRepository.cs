using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface ICropManagementRepository
    {
        Task<IEnumerable<CropManagement>> GetCropManagements();
        Task<CropManagement?> GetCropManagement(int id);
        Task<CropManagement> CreateCropManagement(CropManagement cropManagement);
        Task<CropManagement> UpdateCropManagement(CropManagement cropManagement);
        Task<CropManagement?> DeleteCropManagement(int id);

    }

    public class CropManagementRepository(TabiContext db) : ICropManagementRepository
    {
        public async Task<IEnumerable<CropManagement>> GetCropManagements()
        {
            return await db.CropManagements.ToListAsync();
        }

        public async Task<CropManagement?> GetCropManagement(int id)
        {
            return await db.CropManagements.FindAsync(id);
        }

        public async Task<CropManagement> CreateCropManagement(CropManagement cropManagement)
        {
            db.CropManagements.Add(cropManagement);
            await db.SaveChangesAsync();
            return cropManagement;
        }

        public async Task<CropManagement> UpdateCropManagement(CropManagement cropManagement)
        {
            db.Entry(cropManagement).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropManagement;
        }

        public async Task<CropManagement?> DeleteCropManagement(int id)
        {
            CropManagement? cropManagement = await db.CropManagements.FindAsync(id);
            if (cropManagement == null) return cropManagement;
            cropManagement.IsActive = false;
            db.Entry(cropManagement).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return cropManagement;
        }
    }
}
