using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasypayPaymentSolution.Models
{
    public class BankDetails
    {
        public int Id{ get; set; }
        [Required]
        public String AccNo{ get; set; }
        [Required]
        public String RoutingNo { get; set; }
        public String FirstName{ get; set; }
        public String LastName{ get; set; }
        [Required]
        public String Email{ get; set; }
        public float Balance { get; set; }
    }
}