using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    class Product
    {
        //конструктор нового продукта
        public Product(string name, float price)
        {
            m_name = name;
            m_price = price;
            m_isUsageInDiscount = false;
        }
        //получить цену продукта
        public float GetPrice()
        {
            return m_price * (1 - m_currentDiscount);
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
        public void SetDiscount(float value)
        {
            m_currentDiscount = value;
        }

        string m_name;
        float m_price;
        bool m_isUsageInDiscount;
        float m_currentDiscount = 0;
    }
}
