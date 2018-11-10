using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmic_task_2
{
    public class Notebook
    {
        //конструктор
        public Notebook()
        {
            m_tree = new Tree();
        }

        //добавление новой записи
        public void Add(string name)
        {
            if (name.Length > 0)
            {
                m_tree.AddChild(name);
            }
        }
        //получение количества слов начинающихся с переменной word
        public int GetWordsStartWithWordCount(string word)
        {
            if (word.Length > 0)
            {
                return m_tree.GetValueOfWordIncidence(word);
            }
            return 0;
        }

        Tree m_tree;
    }
}
