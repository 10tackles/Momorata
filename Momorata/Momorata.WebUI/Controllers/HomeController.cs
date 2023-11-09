using Momorata.Core.Contracts;
using Momorata.Core.Models;
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

        public ActionResult Index()
        {
            var productList = _context.Collection().ToList();
            return View(productList);
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