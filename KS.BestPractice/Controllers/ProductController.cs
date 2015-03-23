using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KS.BestPractice.Cache.Infrastructure;
using KS.BestPractice.Models;

namespace KS.BestPractice.Controllers
{
    public class ProductController : Controller
    {
        private ICacheManager _cacheManager;
        
        #region Constructor
        public ProductController()
        {
        }
        public ProductController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        #endregion

        public ActionResult Index()
        {
            Product p = new Product {Id = 1, Name = "My first product",Price = 10 };
            _cacheManager.Set(p.Id.ToString(), p, 10);
            Product p1 = _cacheManager.Get<Product>("1");
            string a  =_cacheManager.GetType().ToString();
            return View(p1);
        }

    }
}
