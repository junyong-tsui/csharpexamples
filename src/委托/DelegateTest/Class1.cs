using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    public class T1Delegate
    {
        public void Do(Action argHandler)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("=========================");
            argHandler();
            Console.WriteLine("=========================");
            Console.WriteLine("=========================");
        }

    }
}
