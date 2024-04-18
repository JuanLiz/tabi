using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ICropService
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop?> GetCrop(int id);
        Task<Crop> CreateCrop(
            int LotID,
            float Hectares,
            int CropTypeID,
            int CropStateID,
            DateOnly PlantingDate,
            DateOnly? HarvestDate
            );
        Task<Crop> UpdateCrop(
            int CropID,
            int? LotID,
            float? Hectares,
            int? CropTypeID,
            int? CropStateID,
            DateOnly? PlantingDate,
            DateOnly? HarvestDate
            );
        Task<Crop?> DeleteCrop(int id);

        public class CropService(ICropRepository cropRepository) : ICropService
        {
            public async Task<IEnumerable<Crop>> GetCrops()
            {
                return await cropRepository.GetCrops();
            }

            public async Task<Crop?> GetCrop(int id)
            {
                return await cropRepository.GetCrop(id);
            }

            public async Task<Crop> CreateCrop(
                int LotID,
                float Hectares,
                int CropTypeID,
                int CropStateID,
                DateOnly PlantingDate,
                DateOnly? HarvestDate
            )
            {
                Crop crop = new()
                {
                    LotID = LotID,
                    Hectares = Hectares,
                    CropTypeID = CropTypeID,
                    CropStateID = CropStateID,
                    PlantingDate = PlantingDate,
                    HarvestDate = HarvestDate
                };
                return await cropRepository.CreateCrop(crop);
            }

            public async Task<Crop> UpdateCrop(
                int CropID,
                int? LotID,
                float? Hectares,
                int? CropTypeID,
                int? CropStateID,
                DateOnly? PlantingDate,
                DateOnly? HarvestDate
            )
            {
                Crop? crop = await cropRepository.GetCrop(CropID);
                if (crop == null) throw new Exception("Crop not found");
                crop.LotID = LotID ?? crop.LotID;
                crop.Hectares = Hectares ?? crop.Hectares;
                crop.CropTypeID = CropTypeID ?? crop.CropTypeID;
                crop.CropStateID = CropStateID ?? crop.CropStateID;
                crop.PlantingDate = PlantingDate ?? crop.PlantingDate;
                crop.HarvestDate = HarvestDate ?? crop.HarvestDate;
                return await cropRepository.UpdateCrop(crop);
            }

            public async Task<Crop?> DeleteCrop(int id)
            {
                return await cropRepository.DeleteCrop(id);
            }
        }
    }
}
