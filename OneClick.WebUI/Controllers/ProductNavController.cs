using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.Controllers
{
    public class ProductNavController : Controller
    {
        private IProductRepository repository2;

        public ProductNavController(IProductRepository repo2)
        {
            repository2 = repo2;
        }
        public PartialViewResult ProductNavMenu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository2.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}

