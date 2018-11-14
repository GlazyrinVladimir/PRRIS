using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    public class Product
    {
        public IProductDiscount p_discount { get; set; }

        //конструктор нового продукта
        public Product(string name, ICurrency price, IProductDiscount pd)
        {
            m_name = name;
            m_price = price;
            p_discount = pd;
        }

        //получить цену продукта
        public float GetPrice()
        {
            return p_discount.GetPrice(m_price.GetValue());
        }

        public ICurrency GetCurrencyPrice()
        {
            return m_price;
        }

        //получить наименование продукта
        public string GetProductName()
        {
            return m_name;
        }

        string m_name;
        ICurrency m_price;
    }

    public interface IProductDiscount
    {
        //установить скидку на продукт
        void SetDiscount(Product p, IDiscount discount);

        //установить, что продукт используется в скидке
        void SetUsageInDiscount();

        //получить используется ли продукт в скидке
        bool GetUsageInDiscount(Product p);

        float GetPrice(float price);
    }

    public class ProductDiscount : IProductDiscount
    {
        public ProductDiscount()
        {
            m_isUsageInDiscount = false;
            m_currentDiscount = new IDiscount();
        }
        //установить скидку на продукт
        public void SetDiscount(Product p, IDiscount discount)
        {
            m_currentDiscount = discount;
        }

        //установить, что продукт используется в скидке
        public void SetUsageInDiscount()
        {
            m_isUsageInDiscount = true;
        }

        //получить используется ли продукт в скидке
        public bool GetUsageInDiscount(Product p)
        {
            return m_isUsageInDiscount;
        }
        
        public float GetPrice(float price)
        {
            return m_currentDiscount.GetPrice(price);
        }

        bool m_isUsageInDiscount;
        IDiscount m_currentDiscount;
    }
}
