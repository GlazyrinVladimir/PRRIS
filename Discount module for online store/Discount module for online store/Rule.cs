using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiscountModuleForOnlineStore
{

    public class RulesController
    {
        //конструктор
        public RulesController()
        {
            rules = new List<IRule>();
        }
        //добавление новой акции
        public void AddRule(IRule rule)
        {
            rules.Add(rule);
        }
        //установка всех скидок к данной тележке
        public void SetAllDiscounts(ref ShoppingCart cart)
        {
            foreach (IRule rule in rules)
            {
                rule.SetDiscountOnProducts(ref cart);
            }
        }
        //список всех скидок
        List<IRule> rules;
    }

    //интерфейс для классов типа правил
    public class IRule
    {
        //виртуальный метод установления скидки на продукты
        public virtual void SetDiscountOnProducts(ref ShoppingCart cart) { }
        //скидка
        public IDiscount m_discount;
        //список с продуктами, которые не участвуют в скидке
        public List<Product> m_productsNotInDiscount;
    }

    //класс для скидок типа купи каждый продукт из списка
    public class RuleBuyItAll : IRule
    {
        //конструктор
        public RuleBuyItAll(IDiscount discount, List<Product> productsInDiscount, List<Product> productsNotInDiscount)
        {
            m_discount = discount;
            m_productsNotInDiscount = productsNotInDiscount;
            m_productsInDiscount = productsInDiscount;
        }
        //переопределенный метод установления скидок
        public override void SetDiscountOnProducts(ref ShoppingCart cart)
        {
            while (isRuleAvailable(ref cart)) ;
        }
        //проверка на выполнение правила для данной корзины
        bool isRuleAvailable(ref ShoppingCart cart)
        {
            List<Product> products = cart.GetProductsList();
            //список для хранения объектов продуктов, которые участвуют в скидке
            List<Product> availableProducts = new List<Product>();
            //каждый продукт из списка продуктов участвующих в скидке
            foreach (Product p in m_productsInDiscount)
            {
                //и каждый продукт из корзины 
                for (int i = 0; i < products.Count; i++)
                {
                    //сравниваются, если это одинаковые продукты и продукт из корзины не участвует в акции, то его добавляем в список
                    if (p.GetProductName() == products[i].GetProductName() && !products[i].GetUsageInDiscount())
                    {
                        availableProducts.Add(products[i]);
                        break;
                    }
                }
            }
            //если все продукты участвующие в скидке находятся в списке найденных, то мы устанавливаем на них скидку
            if (availableProducts.Count == m_productsInDiscount.Count)
            {
                foreach (Product p in availableProducts)
                {
                    p.SetDiscount(m_discount);
                    p.SetUsageInDiscount();
                }
                //проверяем каждый продукт, на который установили скидку, накладывается на него скидка или нет
                foreach (Product p in m_productsNotInDiscount)
                {
                    foreach (Product p2 in availableProducts)
                    {
                        if (p2.GetProductName() == p.GetProductName())
                        {
                            p2.SetDiscount(new IDiscount());
                        }
                    }
                }
                return true;
            }
            return false;
        }
        //список продуктов, участвующих в акции
        List<Product> m_productsInDiscount;
    }
    //класс скидок типа купи больше какого-то значения
    public class RuleBuyMoreThan : IRule
    {
        //конструктор
        public RuleBuyMoreThan(IDiscount discount, List<Product> productsNotInDiscount, int amount)
        {
            m_discount = discount;
            m_productsNotInDiscount = productsNotInDiscount;
            m_amount = amount;
        }
        //переопределенный метод установления скидок
        public override void SetDiscountOnProducts(ref ShoppingCart cart)
        {
            if (cart.GetProductAmount() >= m_amount)
            {
                cart.SetDiscount(m_discount, m_productsNotInDiscount);
                cart.SetProductsNotInDiscount(m_productsNotInDiscount);
            }
        }

        int m_amount;
    }
}