using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ICropTypeService
    {
        Task<IEnumerable<CropType>> GetCropTypes();
        Task<CropType?> GetCropType(int id);

        Task<CropType> CreateCropType(string Name, float ExpectedYield);

        Task<CropType> UpdateCropType(int CropTypeID, string? Name, float? ExpectedYield);
        Task<CropType?> DeleteCropType(int id);

    }

    public class CropTypeService(ICropTypeRepository cropTypeRepository) : ICropTypeService
    {
        public async Task<IEnumerable<CropType>> GetCropTypes()
        {
            return await cropTypeRepository.GetCropTypes();
        }

        public async Task<CropType?> GetCropType(int id)
        {
            return await cropTypeRepository.GetCropType(id);
        }

        public async Task<CropType> CreateCropType(string Name, float ExpectedYield)
        {
            CropType cropType = new() { Name = Name, ExpectedYield = ExpectedYield };
            return await cropTypeRepository.CreateCropType(cropType);
        }

        public async Task<CropType> UpdateCropType(int CropTypeID, string? Name, float? ExpectedYield)
        {
            CropType? cropType = await cropTypeRepository.GetCropType(CropTypeID);
            if (cropType == null) throw new Exception("CropType not found");
            cropType.Name = Name ?? cropType.Name;
            cropType.ExpectedYield = ExpectedYield ?? cropType.ExpectedYield;
            return await cropTypeRepository.UpdateCropType(cropType);
        }

        public async Task<CropType?> DeleteCropType(int id)
        {
            return await cropTypeRepository.DeleteCropType(id);
        }
    }
}
