using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class HarvestPayment
    {
        [Key]
        public int HarvestPaymentID { get; set; }
        [ForeignKey(nameof(Harvest))]
        [Sieve(CanFilter = true, CanSort = true)]
        public int HarvestID { get; set; }
        [ForeignKey(nameof(User))]
        [Sieve(CanFilter = true, CanSort = true)]
        public int? UserID { get; set; }
        public required float HarvestedAmount { get; set; }
        [ForeignKey(nameof(PaymentType))]
        public required int PaymentTypeID { get; set; }
        public required float PaymentAmount { get; set; }
        public required DateOnly PaymentDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual Harvest? Harvest { get; set; }
        public virtual User? User { get; set; }
        public virtual PaymentType? PaymentType { get; set; }

    }
}
