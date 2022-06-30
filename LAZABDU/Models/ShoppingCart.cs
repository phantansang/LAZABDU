using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAZABDU.Models
{
    public class ShoppingCart
    {
        public string _customer { get; set;}
        public List<ProductsCart> _productCarts = new List<ProductsCart>();
        public int _cartQuantity { get; set; }
        public int _cartTotal { get; set; }
        public DateTime _createTime { get; set; }
        public DateTime _lastUpdate { get; set; }
        public ShoppingCart()
        {
            if(HttpContext.Current.Session["CustomerUsername"] != null)
            {
                _customer = (string)HttpContext.Current.Session["CustomerUsername"];
            }
            else _customer = null;
            _productCarts = new List<ProductsCart>();
            _cartQuantity = 0;
            _cartTotal = 0;
            _createTime = DateTime.Now;
            _lastUpdate = DateTime.Now;
        }
        public void UpdateShoppingCart()
        {
            int UpdateTotal = 0;
            int UpdateQuantity = 0;
            foreach (ProductsCart _productsCart in _productCarts)
            {
                UpdateQuantity += _productsCart._quantity;
                UpdateTotal += _productsCart._total;
            }
            _cartTotal = UpdateTotal;
            _cartQuantity = UpdateQuantity;
            _lastUpdate = DateTime.Now;
        }
        public void Add(ProductsCart productsCart)
        {
            if(_productCarts.Count > 0)
            {
                bool checkExist = false;
                foreach (ProductsCart existingProd in _productCarts)
                {
                    if(existingProd._product.C_ID == productsCart._product.C_ID)
                    {
                        existingProd._quantity += productsCart._quantity;
                        existingProd._total = existingProd._price * existingProd._quantity;
                        UpdateShoppingCart();
                        checkExist = true;
                        break;
                    }
                }
                if (checkExist == false)
                {
                    _productCarts.Add(productsCart);
                    UpdateShoppingCart();
                }
            }
            else
            {
                _productCarts.Add(productsCart);
                UpdateShoppingCart();
            }
        }
        public void Delete(ProductsCart prod)
        {
            _productCarts.Remove(prod);
            UpdateShoppingCart();
        }
    }
}