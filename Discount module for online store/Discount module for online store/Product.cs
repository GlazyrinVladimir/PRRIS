using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    public class Product
    {
        //конструктор нового продукта
        public Product(string name, float price)
        {
            m_name = name;
            m_price = price;
            m_isUsageInDiscount = false;
            m_currentDiscount = new IDiscount();
        }
        //получить цену продукта
        public float GetPrice()
        {
            return m_currentDiscount.GetPrice(m_price);
        }
        //установить, что продукт используется в скидке
        public void SetUsageInDiscount()
        {
            m_isUsageInDiscount = true;
        }
        //получить используется ли продукт в скидке
        public bool GetUsageInDiscount()
        {
            return m_isUsageInDiscount;
        }
        //получить наименование продукта
        public string GetProductName()
        {
            return m_name;
        }
        //установить скидку на продукт
        public void SetDiscount(IDiscount discount)
        {
            m_currentDiscount = discount;
        }

        string m_name;
        float m_price;
        bool m_isUsageInDiscount;
        IDiscount m_currentDiscount;
    }
}
