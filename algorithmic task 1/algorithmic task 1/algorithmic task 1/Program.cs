using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

//тест с текстом весом в ~100мб проходит за ~ 4 секунды
//тест с текстом весом в ~60мб проходит за ~ 2.7 секунды
//тест с текстом весом в ~30мб проходит за ~ 1.4 секунды
//тест с текстом весом в ~15мб проходит за ~ 0.7 секунды

namespace algorithmic_task_1
{
    class Program
    {
        int SearchMaxAndMinLength(List<string> list, string s1, string s2)
        {
            int s1First = -1;
            int s2First = -1;
            int s1End = -1;
            int s2End = -1;

            int maxLength = -1;
            int minLength = list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == s1)
                {
                    if (s1First == -1)
                    {
                        s1First = i;
                        s1End = i;
                    }
                    else
                    {
                        s1End = i;
                    }

                    if (s1End > -1 && s2End > -1 && minLength > Math.Abs(s1End - s2End))
                    {
                        minLength = Math.Abs(s1End - s2End);
                    }
                }

                if (list[i] == s2)
                {
                    if (s2First == -1)
                    {
                        s2First = i;
                        s2End = i;
                    }
                    else
                    {
                        s2End = i;
                    }


                    if (s1End > -1 && s2End > -1 && minLength > Math.Abs(s1End - s2End))
                    {
                        minLength = Math.Abs(s1End - s2End);
                    }
                }
            }
            maxLength = Math.Abs(s1First - s2End);
            if (Math.Abs(s1First - s2End) > Math.Abs(s1End - s2First))
            {
                maxLength = Math.Abs(s1First - s2End);
            }
            else
            {
                maxLength = Math.Abs(s1End - s2First);
            }
            Console.WriteLine((maxLength - 1) + " " + (minLength - 1));
            return 0;
        }

        public void FillList(string line, List<string> list)
        {
            String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                list.Add(word);
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
                    FillList(sLine, list);
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
            p.SearchMaxAndMinLength(list, "day", "Today");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);
            Console.ReadKey();
        }
    }
}
