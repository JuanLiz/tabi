using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ICropStateService
    {
        Task<IEnumerable<CropState>> GetCropStates();
        Task<CropState?> GetCropState(int id);
        Task<CropState> CreateCropState(string Name);
        Task<CropState> UpdateCropState(int CropStateID, string? Name);
        Task<CropState?> DeleteCropState(int id);

    }

    public class CropStateService(ICropStateRepository cropStateRepository) : ICropStateService
    {
        public async Task<IEnumerable<CropState>> GetCropStates()
        {
            return await cropStateRepository.GetCropStates();
        }

        public async Task<CropState?> GetCropState(int id)
        {
            return await cropStateRepository.GetCropState(id);
        }

        public async Task<CropState> CreateCropState(string Name)
        {
            CropState cropState = new() { Name = Name };
            return await cropStateRepository.CreateCropState(cropState);
        }

        public async Task<CropState> UpdateCropState(int CropStateID, string? Name)
        {
            CropState? cropState = await cropStateRepository.GetCropState(CropStateID);
            if (cropState == null) throw new Exception("CropState not found");
            cropState.Name = Name ?? cropState.Name;
            return await cropStateRepository.UpdateCropState(cropState);
        }

        public async Task<CropState?> DeleteCropState(int id)
        {
            return await cropStateRepository.DeleteCropState(id);
        }
    }
}
