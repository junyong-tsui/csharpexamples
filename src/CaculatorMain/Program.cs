using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCaculator;

namespace CaculatorMain
{
    /* 遇到问题总结
     *
     * 1.net应用程序的加载是依赖于配置文件的,.net framework安装的时候就会默认带有machine.config和web.config
     * 的,而.net配置文件机制是下层配置继承上层的配置，下层配置和上层配置重复时候优先下层配置。桌面应用程序的顶级配置文件
     * 会继承来自machine.config的配置.
     * 
     * 2.反射加载程序集的时候需要指定反射程序集文件的路径,这个时候需要约定反射程序集的存放路径;否则由于不知道反射
     * 的程序集文件的位置而导致反射失败。  
     * 
     * 3本计算器约定ConcreteCaculator工程输出的dll在当前程序(CaculatorMain.exe)的父目录debug下面，取的时候根据当前
     * exe所在目录加上配置文件存的反射程序集的名称 =》形成反射的dll文件的物理路径
     * 
     * 
     * 4反射的dll的配置文件应该放在本程序的下面，本程序加载的类库下面是没有效果的，除非手动指定配置文件的加载路径。
     * 这是由于.net加载配置文件的默认为当前执行的exe所在应用程序的根目录  
     * 
     * 
     * 5项目工程生成策略探索:
     *     
     *     1循环遍历A引用的项目工程lst,查找lst中的项目工程生成的dll(没有则生成(方式与A一致)):若引用的工程的dll与当前工程下的dll完全一致，则跳过；
     *  否则将dll拷贝到当前工程A的debug目录下。并记录当前项目工程A是否需要重新生成(引用的全部跳过时)
     *     
     *     2根据1中判断当前项目工程是否需要生成，若要则在debug目录下生成新的dll文件。 
     */

    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("请输入操作数1:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作数2:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作符");
            string operators = Console.ReadLine();


            var caculator = CaculatorSimpleFactory.GetCaclulator(operators, num1, num2);

            Console.WriteLine("{0}计算结果:{1}", operators, caculator.Caculate());

            Console.WriteLine("是否继续Y/N");

            if (Console.ReadLine() == "Y") goto Start;

            Console.ReadKey();
        }
    }
}
