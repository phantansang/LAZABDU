using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAZABDU.Models;

namespace LAZABDU.Controllers
{
    public class HomeController : Controller
    {
        private readonly LAZABDU_VN_DBEntities DB = new LAZABDU_VN_DBEntities();
        public ActionResult Index()
        {
            List<Product> _products = DB.Products.ToList();
            List<ProductCategory> _prentCategories = DB.ProductCategories.Where(R => R.C_IDParent == null || R.C_IDParent == "").OrderBy(S => S.C_Priority).ToList();
            List<ProductCategory> _childCategories = DB.ProductCategories.Where(R => R.C_IDParent != null && R.C_IDParent != "").OrderBy(S => S.C_Priority).ToList();
            ViewBag.prentCategories = _prentCategories;
            ViewBag.childCategories = _childCategories;
            return View(_products);
        }
        public PartialViewResult MainMenu()
        {
            List<ProductCategory> _parentCategories = DB.ProductCategories.AsNoTracking().Where(R => R.C_IDParent == null || R.C_IDParent == "").OrderBy(S => S.C_Priority).ToList();
            ViewBag.parentCategories = _parentCategories;
            return PartialView();
        }
        public PartialViewResult MobileMenu()
        {
            List<ProductCategory> _parentCategories = DB.ProductCategories.AsNoTracking().Where(R => R.C_IDParent == null || R.C_IDParent == "").OrderBy(S => S.C_Priority).ToList();
            ViewBag.parentCategories = _parentCategories;
            return PartialView();
        }
    }
}