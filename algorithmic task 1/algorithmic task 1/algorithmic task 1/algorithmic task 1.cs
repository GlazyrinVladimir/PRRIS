using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace algorithmic_task_1
{
    public class Program
    {
        void UpdateParams(ref int s1, ref int s2, int i)
        {
            if (s1 == -1)
            {
                s1 = i;
                s2 = i;
            }
            else
            {
                s2 = i;
            }
        }
        //поиск максимальной и минимальной длины путем запоминания индексов первой и последней встречи слова
        public KeyValuePair<int, int> SearchMaxAndMinLength(List<string> list, string s1, string s2)
        {
            //объявление переменных хранения позиций встреч слов
            int s1First = -1;
            int s2First = -1;
            int s1End = -1;
            int s2End = -1;

            int maxLength = -1;
            int minLength = list.Count;

            s1 = s1.ToLower();
            s2 = s2.ToLower();
            //перебор всех слов в списке
            for (int i = 0; i < list.Count; i++)
            {
                //при встрече слова 1, обновляем переменные
                if (list[i] == s1)
                {
                    UpdateParams(ref s1First, ref s1End, i);
                }

                //при встрече слова 1, обновляем переменные
                if (list[i] == s2)
                {
                    UpdateParams(ref s2First, ref s2End, i);
                }
                //если определены значения переменных содержащих последнее значение индекса встречи 1-ого и 2-ого слова и их разница меньше минимальной длины, то обновляем значение мин длины
                if (s1End > -1 && s2End > -1 && minLength > Math.Abs(s1End - s2End))
                {
                    minLength = Math.Abs(s1End - s2End);
                }
            }
            //если переменные хранят значения индексов встречи слов 1 и 2, то определяем максимальный путь между первой встречей 1-ого слова и последней 2-ого и наоборот
            if (s1First > -1 && s2First > -1)
            {
                maxLength = Math.Abs(s1First - s2End);
                if (maxLength < Math.Abs(s2First - s1End))
                {
                    maxLength = Math.Abs(s2First - s1End);
                }
            }
            return new KeyValuePair<int, int> (maxLength - 1, minLength - 1);
        }
        //заполнение списка словами из строки
        public void FillList(string line, List<string> list)
        {
            String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                list.Add(word.ToLower());
            }
        }
        //заполнение списка словами из файла
        public List<string> LoadText(string name)
        {
            List<string> list = new List<string>();
            StreamReader objReader = new StreamReader(name);
            string sLine = "";
            
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    FillList(sLine.ToLower(), list);
                }
            }
            objReader.Close();
            return list;
        }

        static void Main(string[] args)
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";

            Program p = new Program();
            List<string> list = new List<string>(); //p.LoadText("../../text4.txt");
            p.FillList(s, list);

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "Today", "day");

            if (answer.Value == list.Count && answer.Key == -1)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine((answer.Key) + " " + (answer.Value));
            }
        
            Console.ReadKey();
        }
    }
}
