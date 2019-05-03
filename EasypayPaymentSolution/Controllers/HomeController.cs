using EasypayPaymentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace EasypayPaymentSolution.Controllers
{

    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            EasypayDBContext eDBContext = new EasypayDBContext();
            string uName = User.Identity.GetUserName().ToString();
            BankDetails bDetails = eDBContext.bnkDetails.Where(f => f.Email == uName).ToList().FirstOrDefault();
            if(bDetails==null)
            {
                bDetails = new BankDetails();
                bDetails.Email = "Bank Details need to be configured before proceeding";
            }
            return View(bDetails);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}