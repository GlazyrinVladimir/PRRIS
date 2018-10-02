using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiscountModuleForOnlineStore
{
    //перечисление типов правил. buymorethan - правило покупки больше какого-то числа, buyitall - правило покупки всех товаров из списка
    enum RuleType { BuyMoreThan, BuyItAll };

    class Rule
    {
        //конструктор правила
        public Rule(XmlNode node)
        {
            if (node.Attributes.Count > 0)
            {
                XmlNode attr = node.Attributes.GetNamedItem("type");
                if (attr != null)
                {
                    m_productsNotInDiscount = new List<string>();
                    //выбор какое правило получено
                    switch (attr.Value)
                    {
                        case "buy more":
                            {
                                FillParamsForTypeBuyMoreThan(node);
                                break;
                            }
                        case "buy all":
                            {
                                FillParamsForTypeBuyAll(node);
                                break;
                            }
                    }

                }
            }
        }
        //заполнение параметров для правил типа buyitall
        void FillParamsForTypeBuyAll(XmlNode node)
        {
            m_rType = RuleType.BuyItAll;
            m_productsInDiscount = new List<string>();

            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "productsInRule":
                        {
                            FillList(m_productsInDiscount, childnode.InnerText);
                            break;
                        }
                    case "productsNotInRule":
                        {
                            FillList(m_productsNotInDiscount, childnode.InnerText);
                            break;
                        }
                    case "discount":
                        {
                            m_discount = Convert.ToInt32(childnode.InnerText);
                            break;
                        }
                }
            }
        }
        //заполнение параметров для правил типа buymorethan
        void FillParamsForTypeBuyMoreThan(XmlNode node)
        {
            m_rType = RuleType.BuyMoreThan;

            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "amount":
                        {
                            m_amount = Convert.ToInt32(childnode.InnerText);
                            break;
                        }
                    case "discount":
                        {
                            m_discount = Convert.ToInt32(childnode.InnerText);
                            break;
                        }
                    case "productsNotInRule":
                        {
                            FillList(m_productsNotInDiscount, childnode.InnerText);
                            break;
                        }
                }

            }
        }
        //заполнение списка типа string словами из строки line
        void FillList(List<string> list, string line)
        {
            if (line != null && line.Length > 2)
            {
                string[] t = line.Split(' ');
                foreach (string k in t)
                {
                    list.Add(k);
                }
                list.RemoveAt(0);
                list.RemoveAt(list.Count - 1);

            }
        }
        //получение скидки за выполнение данного правила
        public float GetDiscount()
        {
            return m_discount;
        }
        
        //проверка выполнения данного правила 
        public void CheckRuleForAvailable(ShoppingCart products)
        {
            switch (m_rType)
            {
                case RuleType.BuyMoreThan:
                    {
                        if (products.GetProductAmount() >= m_amount)
                        {
                            products.SetDiscount(m_discount / 100, m_productsNotInDiscount);
                        }
                        break;
                    }

                case RuleType.BuyItAll:
                    { 
                        //проверка на наличие товаров участвующих в скидке
                        while (isRuleAvailable(products, false))
                        {
                            //установление скидки на товары
                            isRuleAvailable(products, true);
                        }
                        break;
                    }
            }
        }

        bool isRuleAvailable(ShoppingCart products, bool isMakeUsageInDiscount)
        {
            List<string> productNamesList = products.GetProductsNames();
            int currentProduct = 0;

            //проверка на вхождение имени продукта в список продуктов участвующих в скидке
            for (int i = 0; i < m_productsInDiscount.Count; i++)
            {
                //переменная s хранит i-ый элемент списка скидочных продуктов
                string s = m_productsInDiscount[i];
                //поиск в списке продуктов из корзины наименование элемента s, который не участвует в скидке
                for (int j = 0; j < productNamesList.Count; j++)
                {
                    if (productNamesList[j] == s && !products[j].GetUsageInDiscount())
                    {
                        if (isMakeUsageInDiscount)
                        {
                            //проверка на получение скидки для акций, в которых получают скидку не все товары
                            if (isProductUseInDiscount(productNamesList[j]))
                            {
                                products[j].SetDiscount(m_discount / 100);
                            }
                            products[j].SetUsageInDiscount();
                        }
                        break;
                    }
                    if (j == productNamesList.Count - 1)
                    {
                        return false;
                    }
                }
                currentProduct++;
            }
            return true;
        }

        bool isProductUseInDiscount(string pname)
        {
            foreach (string s in m_productsNotInDiscount)
            {
                if (s == pname)
                {
                    return false;
                }
            }
            return true;
        }

        float m_discount;
        int m_amount;
        RuleType m_rType;
        public List<string> m_productsInDiscount;
        List<string> m_productsNotInDiscount;
    }
}
