using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    //интерфейс для класса типа валюта
    public class ICurrency
    {
        //получить значение
        public virtual float GetValue()
        {
            return m_value;
        }
        //получить курс
        public virtual float GetExchangeRate()
        {
            return m_exchangeRate;
        }
        //конвертировать из одной валюты в другую
        public virtual float Convert(ICurrency value1, ICurrency value2)
        {
            float currentValue = value1.m_value * value1.m_exchangeRate / value2.m_exchangeRate;
            return currentValue;
        }

        public float m_exchangeRate;
        public float m_value;
    }
    //класс валюты рубль
    public class CurrencyRub : ICurrency
    {
        //конструктор класса рубля
        public CurrencyRub()
        {
            m_value = 0;
            m_exchangeRate = 1;
        }
        //конструктор класса рубля со значением
        public CurrencyRub(float value)
        {
            m_value = value;
            m_exchangeRate = 1;
        }
    }
    //класс валюты доллар
    public class CurrencyDollar : ICurrency
    {
        //конструктор класса доллар
        public CurrencyDollar()
        {
            m_value = 0;
            m_exchangeRate = 68;
        }
        //конструктор класса доллар со значением
        public CurrencyDollar(float value)
        {
            m_value = value;
            m_exchangeRate = 68;
        }
    }
}
