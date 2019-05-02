using EasypayPaymentSolution.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasypayPaymentSolution.Controllers
{
    [Authorize]
    public class BankDetailsController : Controller
    {
        // GET: BankDetails
        EasypayDBContext eDBContext = new EasypayDBContext();

        public ActionResult Index()
        {
             string uName = User.Identity.GetUserName().ToString();
             List<BankDetails> bDetails= eDBContext.bnkDetails.Where(f => f.Email == uName).ToList();
            if (bDetails.Count != 0)
                return RedirectToAction("Details", "BankDetails");
            else return View();
        }
        public ActionResult Details()
        {
            string uName = User.Identity.GetUserName().ToString();
            List<BankDetails> bDetails = eDBContext.bnkDetails.Where(f => f.Email == uName).ToList();
            return View(bDetails.FirstOrDefault());
        }
        public ActionResult Create()
        {
            BankDetails bd = new BankDetails();
            bd.AccNo = Request.Form["AccNo"];
            bd.Email = Request.Form["Email"];
                bd.FirstName = Request.Form["FirstName"];
                bd.LastName = Request.Form["LastName"];
                bd.RoutingNo = Request.Form["RoutingNo"];
                bd.Balance = 1000;
                eDBContext.bnkDetails.Add(bd);
                eDBContext.SaveChanges();

                return RedirectToAction("Index");


            return RedirectToAction("Index");
        }
    }
}