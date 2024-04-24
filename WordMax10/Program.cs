using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMax10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkWord10 workWord10 = new WorkWord10();

            workWord10.LoadToDistionary();

            Console.WriteLine("Список 10 слов чаще всего встречающихся в заданном тексте:");
            Console.WriteLine();

            workWord10.WriteDisplayTopWords10();

            Console.ReadKey();
        }
    }
}
