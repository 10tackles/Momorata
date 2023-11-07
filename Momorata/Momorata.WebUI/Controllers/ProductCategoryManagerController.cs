using Momorata.Core.Contracts;
using Momorata.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Momorata.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategoryManager
        IRepository<ProductCategory> _context;

        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            _context = context;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = _context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                _context.Insert(productCategory);
                _context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = _context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = _context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToEdit.Category = productCategory.Category;


                _context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = _context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = _context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}