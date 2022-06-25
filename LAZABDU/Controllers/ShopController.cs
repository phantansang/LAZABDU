using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAZABDU.Models;
using PagedList;

namespace LAZABDU.Controllers
{
    public class ShopController : Controller
    {
        private readonly LAZABDU_VN_DBEntities DB = new LAZABDU_VN_DBEntities();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            List<Product> popularProducts = DB.Products.OrderByDescending(R => R.BookingDetails.Count()).Take(72).ToList();
            ViewBag.Count = popularProducts.Count();
            return View(popularProducts.ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult MasterSiderbar()
        {
            List<ProductCategory> parentCategories = DB.ProductCategories.Where(R => R.C_IDParent == null || R.C_IDParent == "").OrderBy(S=>S.C_Priority).ToList();
            List<String> provinces = new List<string>();
            foreach (var _shop in DB.Shops)
            {
                if (!provinces.Contains(_shop.C_Province))
                {
                    provinces.Add(_shop.C_Province);
                }
            }
            ViewBag.parentCategories = parentCategories;
            ViewBag.provinces = provinces;
            return PartialView();
        }
        public ActionResult ProductsByProductCategory(string Slug, string CateID, int? page)
        {
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            List<Product> products = DB.Products.Where(R => R.ProductCategory.C_ID == CateID).OrderByDescending(R => R.BookingDetails.Count()).Take(72).ToList();
            ViewBag.Count = products.Count();
            ViewBag.Slug = Slug;
            ViewBag.CateID = CateID;
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ProductsByParentProductCategory(string Slug, string CateID, int? page)
        {
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            List<Product> products = DB.Products.Where(R=>R.ProductCategory.C_IDParent == CateID).OrderByDescending(R => R.BookingDetails.Count()).Take(72).ToList();
            ViewBag.Count = products.Count();
            ViewBag.Slug = Slug;
            ViewBag.CateID = CateID;
            return View(products.ToPagedList(pageNumber, pageSize));
        }
    }
}