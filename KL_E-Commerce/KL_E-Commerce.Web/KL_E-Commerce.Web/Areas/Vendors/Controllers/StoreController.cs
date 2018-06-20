using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Domain.Entities.Utilities;
using KL_E_Commerce.Web.Areas.Vendors.Models;
using KL_E_Commerce.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_E_Commerce.Web.Areas.Vendors.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors/Store
        public ActionResult Index(int? id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new CreateStoreViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, DisplayOrder, Line1, Line2, Line3, Zip, State, Country")]
            CreateStoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var addr = new Address
                {
                    Line1 = model.Line1,
                    Line2 = model.Line2,
                    Line3 = model.Line3,
                    Zip = model.Zip,
                    State = model.State,
                    Country = model.Country,
                    DisplayOrder = 0
                };
                var store = new Store { Name = model.Name, Address = addr };
                db.Stores.Add(store);
                db.SaveChanges();
                return View("Index");
            }
            return View(model);
        }

        // Details Page
    }
}