using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }
        
        public required string Name { get; set; }
    }
}
