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

            string b = "al";

            //создаем объект типа записная книжка и добавляем новые записи
            Notebook notebook = new Notebook();
            notebook.Add(a);
            notebook.Add(a1);
            notebook.Add(a2);
            notebook.Add(a3);
            notebook.Add(a4);
            notebook.Add(a5);
            notebook.Add(a13);
            notebook.Add(a14);

            //получаем и выводим количество имен начинающихся на слово b
            Console.WriteLine(notebook.GetWordsStartWithWordCount(b));
            Console.ReadKey();
        }
    }
}
