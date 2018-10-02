using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    class ShoppingCart
    {
        //конструктор корзины
        public ShoppingCart()
        {
            productsList = new List<Product>();
            productsNamesList = new List<string>();
        }
        //добавить продукт в корзину
        public void Add(Product obj)
        {
            Product p = new Product(obj.GetProductName(), obj.GetPrice());
            productsList.Add(p);
            productsNamesList.Add(p.GetProductName());
        }
        //получить количество продуктов в корзине
        public int GetProductAmount()
        {
            return productsList.Count;
        }
        //получить общую цену продуктов в корзине с учетом всех скидок
        public float GetProductsPrice()
        {
            float value = 0;
            foreach (Product p in productsList)
            {
                //проверка каждого продукта на участие в скидке
                if (!productsWithoutDiscount.Contains(p.GetProductName()))
                {
                    value += p.GetPrice() * (1 - m_discount);
                }
                else
                {
                    value += p.GetPrice();
                }
            }
            return value;
        }
        //индексация корзины, возврат продуктов по индексу добавления
        public Product this[int i]
        {
            get { return productsList[i]; }
        }
        //получение наименований всех продуктов в корзине
        public List<string> GetProductsNames()
        {
            return productsNamesList;
        }
        //получение всех объектов класса продукты в корзине
        public List<Product> GetProductsList()
        {
            return productsList;
        }
        //установление скидки на продукты в корзине и списка продуктов, которые не участвуют в правиле
        public void SetDiscount(float value, List<string> list)
        {
            if (value > m_discount)
            {
                m_discount = value;
                productsWithoutDiscount = list;
            }
        }

        List<Product> productsList;
        List<string> productsNamesList;
        List<string> productsWithoutDiscount;
        float m_discount = 0;
    }
}
