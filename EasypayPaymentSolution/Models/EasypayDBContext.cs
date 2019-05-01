using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasypayPaymentSolution.Models
{
    public class EasypayDBContext : DbContext
    {
        public DbSet<BankDetails> bnkDetails { get; set; }
        public DbSet<Transaction> trnsction{ get; set; }
    }
}