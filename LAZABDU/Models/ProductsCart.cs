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
        public ProductsCart(Product product, int quantity, int price)
        {
            _product = product;
            _quantity = quantity;
            _price = price;
            _total = _price * _quantity;
        }
    }
}