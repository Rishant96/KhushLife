using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Domain.Entities.Utilities;
using KL_E_Commerce.Web.Areas.Vendors.Models;
using KL_E_Commerce.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace KL_E_Commerce.Web.Areas.Vendors.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors/Store
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index", controllerName: "Vendor");
            var stores = db.Stores.Where(m => m.VendorId == id).ToList();
            var stockedProducts = new Dictionary<Store, List<StockedInStore>>();
            foreach (var store in stores)
            {
                stockedProducts.Add(store,
                    db.StockedInStores
                    .Include(m => m.Product)
                    .Include(m => m.Product.Product)
                    .Include(m => m.Product.Product.Category)
                    .Where(m => m.StoreId == store.Id)
                    .ToList());
            }
            return View(new IndexStoreViewModel { Stores = stores, StockedProducts = stockedProducts });
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
                var store = new Store { Name = model.Name, Address = addr, VendorId = User.Identity.GetUserId()};
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
            }
            return View(model);
        }

        // Details Page
    }
}