using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

//тест с текстом весом в ~100мб проходит за ~ 8.5 секунды
//тест с текстом весом в ~60мб проходит за ~ 5.5 секунды
//тест с текстом весом в ~30мб проходит за ~ 2.7 секунды
//тест с текстом весом в ~15мб проходит за ~ 1.2 секунды

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

        public KeyValuePair<int, int> SearchMaxAndMinLength(List<string> list, string s1, string s2)
        {
            int s1First = -1;
            int s2First = -1;
            int s1End = -1;
            int s2End = -1;

            int maxLength = -1;
            int minLength = list.Count;

            s1 = s1.ToLower();
            s2 = s2.ToLower();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == s1)
                {
                    UpdateParams(ref s1First, ref s1End, i);
                }

                if (list[i] == s2)
                {
                    UpdateParams(ref s2First, ref s2End, i);
                }
                if (s1End > -1 && s2End > -1 && minLength > Math.Abs(s1End - s2End))
                {
                    minLength = Math.Abs(s1End - s2End);
                }
            }
            if (s1First > -1 && s2End > -1 && s1First > -1 && s2First > -1)
            {
                maxLength = Math.Abs(s1First - s2End);
                if (maxLength < Math.Abs(s2First - s1End))
                {
                    maxLength = Math.Abs(s2First - s1End);
                }
            }
            return new KeyValuePair<int, int> (maxLength - 1, minLength - 1);
        }

        public void FillList(string line, List<string> list)
        {
            String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                list.Add(word.ToLower());
            }
        }

        public List<string> LoadText()
        {
            List<string> list = new List<string>();
            StreamReader objReader = new StreamReader("../../text4.txt");
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<string> list = p.LoadText();
       //     p.FillList(s, list);

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "Today", "day");
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            if (answer.Value == list.Count && answer.Key == -1)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine((answer.Key) + " " + (answer.Value));
            }

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);
            Console.ReadKey();
        }
    }
}
