using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateTest;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            T1Delegate t = new T1Delegate();
            t.Do(T1);
            Console.ReadKey();
        }

        static void T1()
        {
            File.WriteAllText("时间.txt",DateTime.Now.ToString());
        }
    }
}
