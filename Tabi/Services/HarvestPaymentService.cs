using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IHarvestPaymentService
    {
        Task<IEnumerable<HarvestPayment>> GetHarvestPayments();
        Task<HarvestPayment?> GetHarvestPayment(int id);
        Task<HarvestPayment> CreateHarvestPayment(
            int HarvestID,
            int UserID,
            float HarvestedAmount,
            int PaymentTypeID,
            float PaymentAmount,
            DateOnly PaymentDate
            );
        Task<HarvestPayment> UpdateHarvestPayment(
            int HarvestPaymentID,
            int? HarvestID,
            int? UserID,
            float? HarvestedAmount,
            int? PaymentTypeID,
            float? PaymentAmount,
            DateOnly? PaymentDate
            );
        Task<HarvestPayment?> DeleteHarvestPayment(int id);
    }

    public class HarvestPaymentService(IHarvestPaymentRepository harvestPaymentRepository) : IHarvestPaymentService
    {
        public async Task<IEnumerable<HarvestPayment>> GetHarvestPayments()
        {
            return await harvestPaymentRepository.GetHarvestPayments();
        }

        public async Task<HarvestPayment?> GetHarvestPayment(int id)
        {
            return await harvestPaymentRepository.GetHarvestPayment(id);
        }

        public async Task<HarvestPayment> CreateHarvestPayment(
            int HarvestID,
            int UserID,
            float HarvestedAmount,
            int PaymentTypeID,
            float PaymentAmount,
            DateOnly PaymentDate
        )
        {
            HarvestPayment harvestPayment = new()
            {
                HarvestID = HarvestID,
                UserID = UserID,
                HarvestedAmount = HarvestedAmount,
                PaymentTypeID = PaymentTypeID,
                PaymentAmount = PaymentAmount,
                PaymentDate = PaymentDate
            };
            return await harvestPaymentRepository.CreateHarvestPayment(harvestPayment);
        }

        public async Task<HarvestPayment> UpdateHarvestPayment(
            int HarvestPaymentID,
            int? HarvestID,
            int? UserID,
            float? HarvestedAmount,
            int? PaymentTypeID,
            float? PaymentAmount,
            DateOnly? PaymentDate
        )
        {
            HarvestPayment? harvestPayment = await harvestPaymentRepository.GetHarvestPayment(HarvestPaymentID);
            if (harvestPayment == null) throw new Exception("HarvestPayment not found");
            harvestPayment.HarvestID = HarvestID ?? harvestPayment.HarvestID;
            harvestPayment.UserID = UserID ?? harvestPayment.UserID;
            harvestPayment.HarvestedAmount = HarvestedAmount ?? harvestPayment.HarvestedAmount;
            harvestPayment.PaymentTypeID = PaymentTypeID ?? harvestPayment.PaymentTypeID;
            harvestPayment.PaymentAmount = PaymentAmount ?? harvestPayment.PaymentAmount;
            harvestPayment.PaymentDate = PaymentDate ?? harvestPayment.PaymentDate;
            return await harvestPaymentRepository.UpdateHarvestPayment(harvestPayment);
        }

        public async Task<HarvestPayment?> DeleteHarvestPayment(int id)
        {
            return await harvestPaymentRepository.DeleteHarvestPayment(id);
        }
    }
}
