using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_E_Commerce.Web.Areas.Vendors.Controllers
{
    public class HomeController : Controller
    {
        // GET: Vendors/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}