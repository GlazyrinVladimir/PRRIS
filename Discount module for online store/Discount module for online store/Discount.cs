using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    //интерфейс для классов типа скидок
    public class IDiscount
    {
        //стандартный конструктор
        public IDiscount()
        {
            m_discount = 0;
        }
        //виртуальный метод получения цены
        public virtual float GetPrice(float price)
        {
            return price;
        }
        //получение текущей скидки
        public float GetDiscount()
        {
            return m_discount;
        }

        public float m_discount;
    }
    //класс процентной скидки
    public class PercentType : IDiscount
    {
        //конструктор
        public PercentType(float discount)
        {
            m_discount = discount;            
        }
        //переопределенный метод получения цены
        public override float GetPrice(float price)
        {
            return price * (1 - m_discount / 100);
        }
    }
    //класс скидки по значению
    public class ValueType : IDiscount
    {        
        //конструктор
        public ValueType(float discount)
        {
            m_discount = discount;
        }
        //переопределенный метод получения цены
        public override float GetPrice(float price)
        {
            price -= m_discount;
            if (price < 0)
                return 0;
            else
                return price;
        }
    }
}
