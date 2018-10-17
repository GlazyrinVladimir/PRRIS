using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace algorithmic_task_2
{
    class Program
    {
        //добавление имени в словарь
        void AddNewName(string s)
        {
            //проверка на существование ключа первой буквы добавляемого слова
            if (!m_notebook.ContainsKey(s[0]))
            {
                //создание новой пары ключ - значение первой буквы переменной s, список - пустой
                m_notebook.Add(s[0], new List<string>());
            }
            //добавляем новое значение по ключу первой буквы переменной s
            m_notebook[s[0]].Add(s);

        }
        //функция получения числа слов начинающихся со значения переменной word
        int GetValueOfWordIncidence(string word)
        {
            int count = 0;
            //проверка на существование ключа
            if (m_notebook.ContainsKey(word[0]))
            {
                //получение списка строк со словами начинающихся на букву искомого слова
                List<string> partOfNote = m_notebook[word[0]];
                foreach (string s in partOfNote)
                {
                    //если слово из списка начинается с искомого слова, то увеличиваем счетчик
                    if (s.IndexOf(word) == 0)
                        count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            string a = "alex";
            string a1 = "alexey";
            string a2 = "alexandr";
            string a3 = "aleksandr";
            string a4 = "alekalex";
            string a5 = "vova";
            string a6 = "vladimir";
            string a7 = "anton";
            string a8 = "gosha";
            string a9 = "igor";
            string a10 = "sanek";
            string a11 = "andrey";
            string a12 = "misha";
            string a13 = "egor";
            string a14 = "akakii";
            string a15 = "julia";

            string b = "alex";

            Program p = new Program();
            p.AddNewName(a);
            p.AddNewName(a1);
            p.AddNewName(a2);
            p.AddNewName(a3);
            p.AddNewName(a4);
            p.AddNewName(a5);
            p.AddNewName(a6);
            p.AddNewName(a7);
            p.AddNewName(a8);
            p.AddNewName(a9);
            p.AddNewName(a10);
            p.AddNewName(a11);
            p.AddNewName(a12);
            p.AddNewName(a13);
            p.AddNewName(a14);
            p.AddNewName(a15);

            Console.WriteLine("Find " + b + " -> " + p.GetValueOfWordIncidence(b));
            Console.ReadKey();
        }

        Dictionary<char, List<string>> m_notebook = new Dictionary<char, List<string>>();

    }
}
