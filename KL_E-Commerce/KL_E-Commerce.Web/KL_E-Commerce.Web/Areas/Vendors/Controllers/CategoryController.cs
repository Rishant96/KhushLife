using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Web.Areas.Vendors.Models;
using KL_E_Commerce.Web.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_E_Commerce.Web.Areas.Vendors.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = db.Categories.Include(m => m.Attributes).ToList();
            return View(new IndexCategoryViewModel { Categories = model });
        }

        public ActionResult AddAttributePartial(int? id)
        {
            var model = new AddAttributeViewModel() { };
            ViewBag.count = id;
            return PartialView("AddAttributePartial", model);
        }

        // GET: Vendors/Category
        public ActionResult Create(int? id, bool isBase = false)
        {   
            return View(new CreateCategoryViewModel { IsBase = isBase, Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                List<Domain.Entities.Utilities.Attribute> catAttrs = new List<Domain.Entities.Utilities.Attribute>();
                var nameStr = Request.Form["AtrbName"];
                if (nameStr is null) nameStr = "";
                var atrbNames = nameStr.Split(',').Select(sValue => sValue.Trim()).ToList() as List<string>;
                if (atrbNames is null) atrbNames = new List<string>();

                foreach (var atrbName in atrbNames)
                {
                    if (atrbName != "")
                        catAttrs.Add(new Domain.Entities.Utilities.Attribute() { Name = atrbName });
                }

                foreach (var atrb in catAttrs)
                {
                    if (model.Attributes == null) model.Attributes = new List<Domain.Entities.Utilities.Attribute>();
                    model.Attributes.Add(atrb);
                }
                db.Categories.Add(new Category { Name = model.Name, IsBase = model.IsBase, DisplayOrder = 0,
                    Description = model.Description, Attributes = model.Attributes, CategoryId = model.Id});
                
                db.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("Index");
            }
            var model = db.Categories.Include(m => m.Attributes).FirstOrDefault(m => m.Id == id);
            List<Category> children = db.Categories.Where(m => m.CategoryId == model.Id).ToList();
            model.ChildCategories = children;
            if (model == null)
                return View("Index");
            return View(model);
        }
    }
}