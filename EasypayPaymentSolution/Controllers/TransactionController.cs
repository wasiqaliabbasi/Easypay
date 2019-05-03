using EasypayPaymentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace EasypayPaymentSolution.Controllers
{
    [Authorize]
    [HandleError]
    public class TransactionController : Controller
    {
        EasypayDBContext eDBContext = new EasypayDBContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Transfer()
        {
            Transaction trnsction = new Transaction();
            trnsction.ReceiverEmail = Request.Form["ReceiverEmail"];
            Double amount = Convert.ToDouble(Request.Form["Amount"]);
            trnsction.Amount = amount;
            trnsction.SenderEmail = User.Identity.GetUserName().ToString();
            trnsction.tTime = DateTime.Now;
            eDBContext.trnsction.Add(trnsction);


            string senderUName = User.Identity.GetUserName().ToString();
            BankDetails sndrDetails = eDBContext.bnkDetails.Where(f => f.Email == senderUName).ToList().FirstOrDefault();

            sndrDetails.Balance = sndrDetails.Balance - (float)amount;

            string receiverUName = Request.Form["ReceiverEmail"];
            BankDetails receiverDetails = eDBContext.bnkDetails.Where(f => f.Email == receiverUName).FirstOrDefault();

            receiverDetails.Balance = receiverDetails.Balance + (float)amount;

            eDBContext.SaveChanges();
            return View();
        }
        public ActionResult ViewTransactions()
        {
            string UName = User.Identity.GetUserName().ToString();
            List<Transaction> transactions= eDBContext.trnsction.Where(f => f.SenderEmail == UName || f.ReceiverEmail == UName).ToList();
            return View(transactions);
        }
    }
}