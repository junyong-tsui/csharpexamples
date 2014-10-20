using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md5_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Md5Helper.GetMd5FromString("hello"));
            Console.WriteLine(Md5Helper.GetMd5FromFile(@"E:\Structure And Interpretation Of Computer Programs.pdf"));


            Console.Read();
        }
    }
}
