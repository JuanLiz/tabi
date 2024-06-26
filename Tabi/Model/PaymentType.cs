﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
