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
    public class Shop
    {
        //конструктор магазина
        public Shop()
        {
            rulesController = new RulesController();
            m_shoppingCart = new ShoppingCart();
        }
        //добавление нового правило в объект rulesController
        public void AddRule(IRule rule)
        {
            rulesController.AddRule(rule);
        }

        //получение итоговой цены продуктов с учетом скидок, проверка каждого правила скидок
        public float GetSummaryPrice()
        {
            rulesController.SetAllDiscounts(ref m_shoppingCart);
            return (float)Math.Round(m_shoppingCart.GetProductsPrice(), 2);
        }

        public void AddProductToShoppingCart(Product p)
        {
            m_shoppingCart.m_cartContent.Add(p);
        }

        ShoppingCart m_shoppingCart;
        RulesController rulesController;
    }
}
