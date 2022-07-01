using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAZABDU.Models;

namespace LAZABDU.Models
{
    public class Services
    {
        private readonly LAZABDU_VN_DBEntities DB;
        public Services()
        {
            DB = new LAZABDU_VN_DBEntities();
        }
        public Promotion OnPromotion(Product _product)
        {
            Promotion ressult = null;
            if (_product.Promotions != null)
            {
                int TempDiscount = 0;
                foreach (Promotion _promotion in _product.Promotions)
                {
                    if (_promotion.SalesPromotion.C_Status == 1 && _promotion.SalesPromotion.C_From <= DateTime.Now && _promotion.SalesPromotion.C_To >= DateTime.Now)
                    {
                        if(_promotion.SalesPromotion.C_Discount > TempDiscount)
                        {
                            ressult = _promotion;
                            TempDiscount = (int)ressult.SalesPromotion.C_Discount;
                        }
                    }
                }
            }
            return ressult;
        }
    }
}