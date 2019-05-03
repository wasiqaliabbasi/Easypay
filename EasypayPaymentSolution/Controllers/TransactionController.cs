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
            Double amount=0.0;
            try {
                amount = Convert.ToDouble(Request.Form["Amount"]);
                if (amount < 0) throw new Exception();
            }
            catch(Exception e)
            {
                ViewBag.Message = "Invalid Amount Entered";
                return View();
            }
            trnsction.Amount = amount;
            trnsction.SenderEmail = User.Identity.GetUserName().ToString();
            trnsction.tTime = DateTime.Now;
            eDBContext.trnsction.Add(trnsction);

            string receiverUName = Request.Form["ReceiverEmail"];
            BankDetails receiverDetails = eDBContext.bnkDetails.Where(f => f.Email == receiverUName).FirstOrDefault();

            if (receiverDetails == null)
            {
                ViewBag.Message = "Receiver doesn't exist!!";
                return View();
            }

            string senderUName = User.Identity.GetUserName().ToString();
            BankDetails sndrDetails = eDBContext.bnkDetails.Where(f => f.Email == senderUName).ToList().FirstOrDefault();

            sndrDetails.Balance = sndrDetails.Balance - (float)amount;

            receiverDetails.Balance = receiverDetails.Balance + (float)amount;

            eDBContext.SaveChanges();
            ViewBag.Message = "Transaction Successful";
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