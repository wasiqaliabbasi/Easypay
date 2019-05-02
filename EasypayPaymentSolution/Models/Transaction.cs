using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasypayPaymentSolution.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public String ReceiverEmail { get; set; }
        public String SenderEmail { get; set; }
        [Required]
        public Double Amount { get; set; }
        public DateTime tTime { get; set; }
    }
}