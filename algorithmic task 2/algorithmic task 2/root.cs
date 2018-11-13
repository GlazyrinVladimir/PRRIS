using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmic_task_2
{
    public class Root
    {
        //конструктор 
        public Root(char value, Root parent)
        {
            m_childs = new List<Root>();
            m_value = value;
            m_parent = parent;
            m_childsWordEndsCount = 0;
        }

        //возвращаем все следующие корни, текущего корня
        public List<Root> GetChilds()
        {
            return m_childs;
        }

        //добавляем корень следующего от текущего
        public void SetChild(Root child)
        {
            m_childs.Add(child);
        }

        //поиск среди детей корня на букву в переменной value
        public Root FindByValue(char value)
        {
            foreach (Root child in m_childs)
            {
                if (child.m_value == value)
                {
                    return child;
                }
            }
            return null;
        }

        //получить букву, которую хранит корень  
        public char GetValue()
        {
            return m_value;
        }

        //считаем даннный корень концом слова
        public void SetWordEnd()
        {
            m_isWordEnd = true;
            Root parent = m_parent;
            //увеличиваем счетчики количества слов всех верхних корней
            while (parent != null)
            {
                parent.m_childsWordEndsCount++;
                parent = parent.m_parent;
            }
        }

        //возврат значения определяющее конец слова
        public bool GetWordEndState()
        {
            return m_isWordEnd;
        }

        //возврат счетчика всех окончаний слов данной ветви
        public int GetAllWordsEndInBranch()
        {
            int count = 0;
            count += m_childsWordEndsCount;

            foreach (Root child in m_childs)
            {
                count += child.GetAllWordsEndInBranch();
            }
            return count;
        }

        //возврат значения переменной о окончании на данном корне слова
        public bool IsCurrentRootWordEnd()
        {
            return m_isWordEnd;
        }
        //возврат количества детей, на которых оканчивается слово
        public int GetChildsWordEndsCount()
        {
            return m_childsWordEndsCount;
        }

        //буква хранимая в корне
        char m_value;
        //Ссылка на родителя текущего корня
        Root m_parent;
        //все дети текущего корня
        List<Root> m_childs;
        //переменная определяющая окончание слова
        bool m_isWordEnd = false;
        //переменная счетчик, хранит информацию о количестве детей, на которых оканчивается слово
        int m_childsWordEndsCount;
    }
}
