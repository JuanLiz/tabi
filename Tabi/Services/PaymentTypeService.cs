using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<PaymentType?> GetPaymentType(int id);
        Task<PaymentType> CreatePaymentType(string Name);
        Task<PaymentType> UpdatePaymentType(int PaymentTypeID, string? Name);
        Task<PaymentType?> DeletePaymentType(int id);
    }

    public class PaymentTypeService(IPaymentTypeRepository paymentTypeRepository) : IPaymentTypeService
    {
        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await paymentTypeRepository.GetPaymentTypes();
        }

        public async Task<PaymentType?> GetPaymentType(int id)
        {
            return await paymentTypeRepository.GetPaymentType(id);
        }

        public async Task<PaymentType> CreatePaymentType(string Name)
        {
            PaymentType paymentType = new()
            {
                Name = Name
            };
            return await paymentTypeRepository.CreatePaymentType(paymentType);
        }

        public async Task<PaymentType> UpdatePaymentType(int PaymentTypeID, string? Name)
        {
            PaymentType? paymentType = await paymentTypeRepository.GetPaymentType(PaymentTypeID);
            if (paymentType == null) throw new Exception("PaymentType not found");
            paymentType.Name = Name ?? paymentType.Name;
            return await paymentTypeRepository.UpdatePaymentType(paymentType);
        }

        public async Task<PaymentType?> DeletePaymentType(int id)
        {
            return await paymentTypeRepository.DeletePaymentType(id);
        }
    }
}
