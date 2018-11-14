using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountModuleForOnlineStore
{
    public class ICurrency
    {
        public virtual float GetValue()
        {
            return m_value;
        }

        public virtual float GetExchangeRate()
        {
            return m_exchangeRate;
        }

        public virtual float Convert(ICurrency value1, ICurrency value2)
        {
            float currentValue = value1.m_value * value1.m_exchangeRate / value2.m_exchangeRate;
            return currentValue;
        }

        public float m_exchangeRate;
        public float m_value;
    }

    public class CurrencyRub : ICurrency
    {
        public CurrencyRub()
        {
            m_value = 0;
            m_exchangeRate = 1;
        }

        public CurrencyRub(float value)
        {
            m_value = value;
            m_exchangeRate = 1;
        }
    }

    public class CurrencyDollar : ICurrency
    {
        public CurrencyDollar()
        {
            m_value = 0;
            m_exchangeRate = 68;
        }

        public CurrencyDollar(float value)
        {
            m_value = value;
            m_exchangeRate = 68;
        }
    }
}
