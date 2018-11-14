using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    public class ShoppingCart
    {
        public ICartDiscount m_discount { get; set; }
        public ICartContent m_cartContent { get; set; }

        //конструктор корзины
        public ShoppingCart(ICartContent cartCont, ICartDiscount cartDis)
        {
            m_cartContent = cartCont;
            m_discount = cartDis;
        }

        //получить общую цену продуктов в корзине с учетом всех скидок
        public float GetProductsPrice()
        {
            float valueProductsInDiscount = 0;
            float valueProductsNotInDiscount = 0;

            List<string> productsWithoutDiscountNames = new List<string>();

            foreach (Product p in m_discount.GetProductsWithountDiscount())
            {
                productsWithoutDiscountNames.Add(p.GetProductName());
            }
            
            foreach (Product p in m_cartContent.GetProductsList())
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
            return m_discount.GetPriceWithDiscount(valueProductsInDiscount) + valueProductsNotInDiscount;
        }
    }
    //интерфейс cкидок для корзины
    public interface ICartDiscount
    {        
        //установление скидки на продукты в корзине и списка продуктов, которые не участвуют в правиле
        void SetDiscount(IDiscount value, List<Product> list);
        //продукты не участвующие в акции
        void SetProductsNotInDiscount(List<Product> list);
        //получение списка продуктов без скидок
        List<Product> GetProductsWithountDiscount();
        //получение цены продуктов со скидкой
        float GetPriceWithDiscount(float price);
    }
    //реализация интерфейса скидок для корзины
    public class CartDiscount : ICartDiscount
    {
        //конструктор
        public CartDiscount()
        {
            m_productsWithoutDiscount = new List<Product>();
            m_discount = new IDiscount();
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
        //продукты не участвующие в акции
        public void SetProductsNotInDiscount(List<Product> list)
        {
            m_productsWithoutDiscount = list;
        }
        //получение списка продуктов без скидок
        public List<Product> GetProductsWithountDiscount()
        {
            return m_productsWithoutDiscount;
        }
        //получение цены продуктов со скидкой
        public float GetPriceWithDiscount(float price)
        {
            return m_discount.GetPrice(price);
        }

        List<Product> m_productsWithoutDiscount;
        IDiscount m_discount;
    }
    //интерфейс товаров в корзине
    public interface ICartContent
    {        
        //получение наименований всех продуктов в корзине
        List<string> GetProductsNamesList();
        //получение всех объектов класса продукты в корзине
        List<Product> GetProductsList();
        //получить количество продуктов в корзине
        int GetProductAmount();
        //добавить продукт в корзину
        void Add(Product obj);
    }
    //реализация интерфейса товаров в корзине
    public class CartContent : ICartContent
    {
        //конструктор
        public CartContent()
        {
            m_productsList = new List<Product>();
            m_productsNamesList = new List<string>();
        }
        //индексация корзины, возврат продуктов по индексу добавления
        public Product this[int i]
        {
            get { return m_productsList[i]; }
        }
        //получение наименований всех продуктов в корзине
        public List<string> GetProductsNamesList()
        {
            return m_productsNamesList;
        }
        //получение всех объектов класса продукты в корзине
        public List<Product> GetProductsList()
        {
            return m_productsList;
        }

        //добавить продукт в корзину
        public void Add(Product obj)
        {
            Product p = new Product(obj.GetProductName(), obj.GetCurrencyPrice(), new ProductDiscount());
            m_productsList.Add(p);
            m_productsNamesList.Add(p.GetProductName());
        }

        //получить количество продуктов в корзине
        public int GetProductAmount()
        {
            return m_productsList.Count;
        }

        List<Product> m_productsList;
        List<string> m_productsNamesList;
    }
}
