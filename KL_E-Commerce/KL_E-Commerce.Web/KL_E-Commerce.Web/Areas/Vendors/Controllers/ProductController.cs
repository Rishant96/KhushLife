using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Web.Areas.Vendors.Models;
using KL_E_Commerce.Web.DAL;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_E_Commerce.Domain.Entities.Utilities;

namespace KL_E_Commerce.Web.Areas.Vendors.Controllers
{
    public class ProductController : Controller
    {
        private Category category;
        private ApplicationDbContext db = new ApplicationDbContext();

        private void SetCategory(int id)
        {
            category = db.Categories.Include(m => m.Attributes).FirstOrDefault(m => m.Id == id);
        }

        // GET: Vendors/Product
        public ActionResult Index(int? id)

        {
            if(id == null)
            {
                return RedirectToAction("Index", "Category", null);
            }

            category = db.Categories.FirstOrDefault(m => m.Id == id);

            if(category == null)
                return RedirectToAction("Index", "Category", null);

            var products = db.Products.Include(m => m.Category).Include(m => m.Vendor)
                .Include(m => m.Specifications).Where(m => m.CategoryId == category.Id).ToList();
            return View(new IndexProductViewModel { Products = products, Id = (int)id });
        }

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", controllerName: "Category");
            }
            SetCategory((int)id);
            return View(new CreateProductViewModel() { Attributes = category.Attributes.ToList(), Id = (int)id });
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                SetCategory(model.Id);
                var prod = new Product { Name = model.Name };
                prod.CategoryId = category.Id;
                prod.HasVariants = false;

                prod.Specifications = new List<Specification>();
                var specValues = Request.Form["txtValue"];

                if (specValues is null) specValues = "";
                var specValueList = specValues.Split(',').Select(sValue => sValue.Trim()).ToArray();
                if (specValueList is null) specValueList = new string[] { };

                for (int i=0; i < category.Attributes.Count; i++)
                {
                    if(specValueList[i] != "")
                    {
                        prod.Specifications.Add(new Specification
                        {
                            AttributeId = category.Attributes.ElementAt(i).Id,
                            IsVariable = false,
                            SpecOptions = new List<SpecOption> { new SpecOption {
                                            IsPreSelected = true,
                                            IsSelected = true,
                                            SpecCost = 0,
                                            Value = specValueList[i]
                                         } },
                            Name = category.Attributes.ElementAt(i).Name
                        });
                    }
                }

                db.Products.Add(prod);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = model.Id });
            }
            return View(model);
        }

        public ActionResult Stock(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var prod = db.Products.Include(m => m.Specifications).FirstOrDefault(m => m.Id == id);
            if (prod == null) RedirectToAction("Index");
            var model = new StockProductViewModel { Product = prod, ProdId = prod.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Stock([Bind(Include = "Stock,Price")] StockProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                int id = int.Parse(Request.Form["prodID"]);
                model.Product = db.Products.Include(m => m.Specifications).FirstOrDefault(m => m.Id == id);
                var finalSpecs = new List<FinalSpec>();
                foreach(var spec in model.Product.Specifications)
                {
                    finalSpecs.Add(new FinalSpec {
                        AttributeId = spec.AttributeId,
                        Value = spec.SpecOptions.First().Value
                    });
                }
                var stkProd = new StockedProduct
                {
                    ProductId = model.Product.Id,
                    Specifications = finalSpecs
                };
                stkProd = db.StockedProducts.Add(stkProd);
                db.SaveChanges();
                var stkStore = new StockedInStore
                {
                    Price = model.Price,
                    StockedProductId = stkProd.Id,
                    Stock = model.Stock,
                    StoreId = 1,
                    Status = (model.Stock > 0) ? ProductStatus.InStock : ProductStatus.OutOfStock 
                };
                db.StockedInStores.Add(stkStore);
                db.SaveChanges();
                return RedirectToAction("Index", controllerName: "Store");
            }
            return View(model);
        }


    }
}