using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    public class ShoppingCart
    {
        //конструктор корзины
        public ShoppingCart()
        {
            m_productsList = new List<Product>();
            m_productsNamesList = new List<string>();
            m_productsWithoutDiscount = new List<Product>();
            m_discount = new IDiscount();
        }
        //добавить продукт в корзину
        public void Add(Product obj)
        {
            Product p = new Product(obj.GetProductName(), obj.GetPrice());
            m_productsList.Add(p);
            m_productsNamesList.Add(p.GetProductName());
        }
        //получить количество продуктов в корзине
        public int GetProductAmount()
        {
            return m_productsList.Count;
        }
        //получить общую цену продуктов в корзине с учетом всех скидок
        public float GetProductsPrice()
        {
            float valueProductsInDiscount = 0;
            float valueProductsNotInDiscount = 0;

            List<string> productsWithoutDiscountNames = new List<string>();

            foreach (Product p in m_productsWithoutDiscount)
            {
                productsWithoutDiscountNames.Add(p.GetProductName());
            }
            
            foreach (Product p in m_productsList)
            {
                //проверка каждого продукта на участие в скидке
                if (!productsWithoutDiscountNames.Contains(p.GetProductName()))
                {
                    valueProductsInDiscount += p.GetPrice();
                }
                else
                {
                    valueProductsNotInDiscount += p.GetPrice();
                }
            }
          
            return m_discount.GetPrice(valueProductsInDiscount) + valueProductsNotInDiscount;
        }
        //индексация корзины, возврат продуктов по индексу добавления
        public Product this[int i]
        {
            get { return m_productsList[i]; }
        }
        //получение наименований всех продуктов в корзине
        public List<string> GetProductsNames()
        {
            return m_productsNamesList;
        }
        //получение всех объектов класса продукты в корзине
        public List<Product> GetProductsList()
        {
            return m_productsList;
        }
        //продукты не участвующие в акции
        public void SetProductsNotInDiscount(List<Product> list)
        {
            m_productsWithoutDiscount = list;
        }

        //установление скидки на продукты в корзине и списка продуктов, которые не участвуют в правиле
        public void SetDiscount(IDiscount value, List<Product> list)
        {
            if (value.GetDiscount() > m_discount.GetDiscount())
            {
                m_discount = value;
                m_productsWithoutDiscount = list;
            }
        }

        List<Product> m_productsList;
        List<string> m_productsNamesList;
        List<Product> m_productsWithoutDiscount;
        IDiscount m_discount;
    }
}
