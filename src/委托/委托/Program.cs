using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DelegateTest;

namespace 委托
{


    /*
      委托是一个数据类型，是一个类
     */

    class Program
    {
        static void Main(string[] args)
        {
           T1Delegate t=new T1Delegate();
           t.Do(T1);

            Console.ReadKey();
        }

        static void T1()
        {
            Console.WriteLine("当前时间{0}",DateTime.Now.ToString());
        }
    }
}
