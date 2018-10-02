using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;
namespace DiscountModuleForOnlineStore
{
    class Shop
    {
        //конструктор магазина
        public Shop()
        {
            m_shopRules = new List<Rule>();
            m_shoppingCart = new ShoppingCart();
            LoadRules();
        }
        //получение всех правил из xml файла
        void LoadRules()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("rules.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                Rule r = new Rule(xnode);
                m_shopRules.Add(r);
            }
        }
        //получение итоговой цены продуктов с учетом скидок, проверка каждого правила скидок
        public float GetSummaryPrice()
        {
            foreach(Rule r in m_shopRules)
            {
                r.CheckRuleForAvailable(m_shoppingCart);                
            }
            return m_shoppingCart.GetProductsPrice();
        }
        //добавление продукта в объект корзины
        public void AddProductToShoppingCart(Product p)
        {
            m_shoppingCart.Add(p);
        }

        List<Rule> m_shopRules;
        ShoppingCart m_shoppingCart;
    }

}
