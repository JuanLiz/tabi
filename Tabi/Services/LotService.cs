using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface ILotService
    {
        Task<IEnumerable<Lot>> GetLots();
        Task<Lot?> GetLot(int id);
        Task<Lot> CreateLot(
            int FarmID,
            string Name,
            float Hectares,
            int SlopeTypeID);
        Task<Lot> UpdateLot(
            int LotID,
            int? FarmID,
            string? Name,
            float? Hectares,
            int? SlopeTypeID);
        Task<Lot?> DeleteLot(int id);
    }

    public class LotService(ILotRepository lotRepository) : ILotService
    {
        public async Task<IEnumerable<Lot>> GetLots()
        {
            return await lotRepository.GetLots();
        }

        public async Task<Lot?> GetLot(int id)
        {
            return await lotRepository.GetLot(id);
        }

        public async Task<Lot> CreateLot(
            int FarmID,
            string Name,
            float Hectares,
            int SlopeTypeID
        )
        {
            Lot lot = new()
            {
                FarmID = FarmID,
                Name = Name,
                Hectares = Hectares,
                SlopeTypeID = SlopeTypeID
            };
            return await lotRepository.CreateLot(lot);
        }

        public async Task<Lot> UpdateLot(
            int LotID,
            int? FarmID,
            string? Name,
            float? Hectares,
            int? SlopeTypeID
        )
        {
            Lot? lot = await lotRepository.GetLot(LotID);
            if (lot == null) throw new Exception("Lot not found");
            lot.FarmID = FarmID ?? lot.FarmID;
            lot.Name = Name ?? lot.Name;
            lot.Hectares = Hectares ?? lot.Hectares;
            lot.SlopeTypeID = SlopeTypeID ?? lot.SlopeTypeID;
            return await lotRepository.UpdateLot(lot);
        }

        public async Task<Lot?> DeleteLot(int id)
        {
            return await lotRepository.DeleteLot(id);
        }
    }
}
