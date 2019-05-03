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
    [HandleError]
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
            else
            {
                BankDetails bd = new BankDetails();
                bd.Email = uName;
                return View(bd);
            }
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
            bd.Email = User.Identity.GetUserName().ToString();
            bd.FirstName = Request.Form["FirstName"];
                bd.LastName = Request.Form["LastName"];
                bd.RoutingNo = Request.Form["RoutingNo"];
                bd.Balance = 1000;
                eDBContext.bnkDetails.Add(bd);
                eDBContext.SaveChanges();
                return RedirectToAction("Index");




//else ViewBag.CustomError = "ERROR IS HERE";

            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult EditForm()
        {
            string UName = User.Identity.GetUserName().ToString();
            BankDetails bd = eDBContext.bnkDetails.Where(f => f.Email == UName).ToList().FirstOrDefault();
            bd.AccNo= Request.Form["AccNo"];
            bd.AccNo = Request.Form["AccNo"];
            bd.Email = Request.Form["Email"];
            bd.FirstName = Request.Form["FirstName"];
            bd.LastName = Request.Form["LastName"];
            bd.RoutingNo = Request.Form["RoutingNo"];

            eDBContext.bnkDetails.Add(bd);
            eDBContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult kkk()
        {
            ViewBag.CustomError = "This is custom";
            return View();
        }
    }
}