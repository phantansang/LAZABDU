using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAZABDU.Models
{
    public class ProductsCart
    {
        public Product _product { get; set; }
        public int _quantity { get; set; }
        public int _price { get; set; }
        public int _total { get; set; }
        public ProductsCart()
        {
            _product = new Product();
            _quantity = 0;
            _price = 0;
            _total = 0;
        }
        public ProductsCart(Product product, int quantity)
        {
            _product = product;
            _quantity = quantity;
            Services _service = new Services();
            if (_service.OnPromotion(_product) != null)
            {
                Promotion promotion = _service.OnPromotion(_product);
                _price = (int)(_product.C_Price - (_product.C_Price * promotion.SalesPromotion.C_Discount / 100));
            }
            else _price = (int)product.C_Price;
            _total = _price * _quantity;
        }
    }
}