using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018MVC.Models;

namespace CommunityAssist2018MVC.Controllers
{
    public class GrantApplicationController : Controller
    {
        // GET: GrantApplication
        public ActionResult Index()
        {
            var ukey = System.Web.HttpContext.Current.Session["ukey"] as int?;
            if (ukey != null)
            {
                CommunityAssist2017Entities db = new CommunityAssist2017Entities();
                IEnumerable<SelectListItem> slItem = from s in db.GrantTypes
                                     select new SelectListItem
                                     {
                                         Text = s.GrantTypeName,
                                         Value = s.GrantTypeKey.ToString()
                                     };
                ViewBag.GrantTypes = slItem;

                return View();
            }
            else
            {
                var resultMessage = new Message();
                resultMessage.MessageText = "Please log in to apply for assistance.";
                return View("Result", resultMessage);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "GrantApplicationRequestAmount, GrantApplicationReason")]GrantApplication grn)
        {
            var resultMessage = new Message();
            if (ModelState.IsValid)
            {
                CommunityAssist2017Entities db = new CommunityAssist2017Entities();
                var applicant = db.People.Find(System.Web.HttpContext.Current.Session["ukey"] as int? ?? 0);

                grn.GrantAppicationDate = DateTime.Now;
                grn.GrantType = db.GrantTypes.Find(Int32.Parse(Request["GrantType"]));
                grn.GrantApplicationStatu = db.GrantApplicationStatus.Find(1);
                applicant.GrantApplications.Add(grn);
                db.SaveChanges();
                resultMessage.MessageText = "Thank you for applying. We'll contact you as soon as we're able to regarding the status of your request.";
            }
            else
            {
                resultMessage.MessageText = "We're so sorry, something seems to have gone wrong. Please visit us in person to apply for a grant.";
            }
            return View("Result", resultMessage);
        }
    }
}
