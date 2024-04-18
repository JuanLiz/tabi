using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IHarvestService
    {
        Task<IEnumerable<Harvest>> GetHarvests();
        Task<Harvest?> GetHarvest(int id);
        Task<Harvest> CreateHarvest(
            int CropID,
            int HarvestStateID,
            DateOnly Date,
            float Amount);
        Task<Harvest> UpdateHarvest(
            int HarvestID,
            int? CropID,
            int? HarvestStateID,
            DateOnly? Date,
            float? Amount);
        Task<Harvest?> DeleteHarvest(int id);
    }

    public class HarvestService(IHarvestRepository harvestRepository) : IHarvestService
    {
        public async Task<IEnumerable<Harvest>> GetHarvests()
        {
            return await harvestRepository.GetHarvests();
        }

        public async Task<Harvest?> GetHarvest(int id)
        {
            return await harvestRepository.GetHarvest(id);
        }

        public async Task<Harvest> CreateHarvest(
            int CropID,
            int HarvestStateID,
            DateOnly Date,
            float Amount)
        {
            Harvest harvest = new()
            {
                CropID = CropID,
                HarvestStateID = HarvestStateID,
                Date = Date,
                Amount = Amount
            };
            return await harvestRepository.CreateHarvest(harvest);
        }

        public async Task<Harvest> UpdateHarvest(
            int HarvestID,
            int? CropID,
            int? HarvestStateID,
            DateOnly? Date,
            float? Amount)
        {
            Harvest? harvest = await harvestRepository.GetHarvest(HarvestID);
            if (harvest == null) throw new Exception("Harvest not found");
            harvest.CropID = CropID ?? harvest.CropID;
            harvest.HarvestStateID = HarvestStateID ?? harvest.HarvestStateID;
            harvest.Date = Date ?? harvest.Date;
            harvest.Amount = Amount ?? harvest.Amount;
            return await harvestRepository.UpdateHarvest(harvest);
        }

        public async Task<Harvest?> DeleteHarvest(int id)
        {
            return await harvestRepository.DeleteHarvest(id);
        }
    }
}
