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
            List<Product> popularProducts = DB.Products.OrderByDescending(R => R.C_Views).Take(72).ToList();
            ViewBag.Count = popularProducts.Count();
            return View(popularProducts.ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult MasterSiderbar()
        {
            List<Product> bestsellersProducts = DB.Products.OrderByDescending(R => R.BookingDetails.Count()).Take(6).ToList();
            List<ProductCategory> parentCategories = DB.ProductCategories.Where(R => R.C_IDParent == null || R.C_IDParent == "").OrderBy(S=>S.C_Priority).ToList();
            List<String> provinces = new List<string>();
            foreach (var _shop in DB.Shops)
            {
                if (!provinces.Contains(_shop.C_Province))
                {
                    provinces.Add(_shop.C_Province);
                }
            }
            ViewBag.bestsellersProducts = bestsellersProducts;
            ViewBag.parentCategories = parentCategories;
            ViewBag.provinces = provinces;
            return PartialView();
        }
        public ActionResult ProductsByProductCategory(string Slug, string CateID, int? page)
        {
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            ProductCategory category = DB.ProductCategories.Find(CateID);
            List<Product> products = DB.Products.Where(R => R.ProductCategory.C_ID == category.C_ID).OrderByDescending(R => R.BookingDetails.Count()).Take(72).ToList();
            ViewBag.Count = products.Count();
            ViewBag.category = category;
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ProductsByParentProductCategory(string Slug, string CateID, int? page)
        {
            if (page == null) page = 1;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            ProductCategory category = DB.ProductCategories.Find(CateID);    
            List<Product> products = DB.Products.Where(R=>R.ProductCategory.C_IDParent == category.C_ID).OrderByDescending(R => R.BookingDetails.Count()).Take(72).ToList();
            ViewBag.category = category;
            ViewBag.Count = products.Count();
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ProductDetail(string Slug, string ProdID)
        {
            Product detailProduct = DB.Products.Find(ProdID);
            List<Product> relatedProducts = new List<Product>();
            List<Product> alsoLikeProducts = new List<Product>();
            int isExist = 0; //Sản phẩm không tồn tại
            if (detailProduct != null)
            {
                if (detailProduct.C_IsShow == 1)
                {
                    isExist = 1; //Sản phẩm được hiển thị
                    relatedProducts = DB.Products.Where(R => R.C_Cate == detailProduct.C_Cate).Take(10).ToList();
                    alsoLikeProducts = DB.Products.Where(R => R.C_Cate != detailProduct.C_Cate && R.ProductCategory.ParentProductCategory.C_ID == detailProduct.ProductCategory.ParentProductCategory.C_ID).Take(20).ToList();
                }
                else isExist = -1; //Sản phẩm không được hiển thị
            }
            ViewBag.isExist = isExist;
            ViewBag.relatedProducts = relatedProducts;
            ViewBag.alsoLikeProducts = alsoLikeProducts;
            return View(detailProduct);
        }
    }
}