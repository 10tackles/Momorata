using Momorata.Core.Contracts;
using Momorata.Core.Models;
using Momorata.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Momorata.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Product> _context;
        IRepository<ProductCategory> _productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategories)
        {
            _context = productContext;
            _productCategories = productCategories;
        }

        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = _productCategories.Collection().ToList();

            if (Category == null)
            {
                products = _context.Collection().ToList();
            }
            else
            {
                products = _context.Collection().Where(x => x.Category == Category).ToList();
            }


            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = _context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
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