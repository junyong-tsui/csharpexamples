using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类型推断
{
    class Program
    {
        static void Main(string[] args)
        {
            //强类型，在编译的时候就已经确定数据类型

            //string n = "aaaa";
            //n = 10;

            #region 4.0DLR

            //弱类型,在编译时候不确定数据类型
            dynamic d = new ExpandoObject();

            d.Name = "abc";


            #endregion


            #region C#中的Var是强类型

            //var依然是强类型的,
            //编译器会在编译的时候将其替换为对应的数据类型
            //编译器会更具"="右边的数据类型自动推断出应该是什么数据类型，就会将
            //var替换为相应的数据类型
            //var只能用在方法的局部变量中，若应用其他则无法推断。

            var n = 100;

            var s = "aaa";

            #endregion
        }
    }
}


/*
 * 已使用快捷键(赋值、粘贴、查找、全选、撤销操作就不用说了）
 * 导航 Ctrl - 后退，f12前进
 * shift+alt+f10 生成方法
 * Ctrl+N 新建文件
 */
