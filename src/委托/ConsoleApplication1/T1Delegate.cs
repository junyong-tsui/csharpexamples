using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class T1Delegate
    {
        public void Do(Action argHandler)
        {
            Console.WriteLine( "=========================");
            Console.WriteLine("=========================");
            argHandler();
            Console.WriteLine("=========================");
            Console.WriteLine("=========================");
        }

    }
}
