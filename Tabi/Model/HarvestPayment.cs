using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class HarvestPayment
    {
        [Key]
        public int HarvestPaymentID { get; set; }
        
        [Required]
        [ForeignKey(nameof(Harvest))]
        public int HarvestID { get; set; }
        
        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        
        [Required]
        public float HarvestedAmount { get; set; }
        
        [Required]
        [ForeignKey(nameof(PaymentType))]
        public int PaymentTypeID { get; set; }
        
        [Required]
        public float PaymentAmount { get; set; }


        public Harvest Harvest { get; set; } = null!;
        public User User { get; set; } = null!;
        public PaymentType PaymentType { get; set; } = null!;

    }
}
