using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace linq_to_objects
{

    /*定义描述
       序列：
     *     linq to objects:实现了IEnumerable<T>,IEnumerable 的对象
     *     linq to provider:实现了IQuerable<T>,IQuerable的对象
     * linq中的方法语法或者查询语法返回的都是序列,这也是链式编程的基础，Linq框架的核心之一就是链式编程原理。
     * 
     * linq 查询的两种方式：
     *      方法语法：连缀调用Enumerable /Querable中的扩展方法
     *      查询语法: from join where orderby select/group等类似于sql语法,其实是编译器的烟雾弹而已，最终会编译成
     *  相应的方法语法，且查询语法只会对应部分的方法语法。语法要求必须以select或者group结束
     *  
     * linq子查询概念：
     *      其实就是外层序列查询时候用到了子序列
     */


    class Program
    {
        static void Main(string[] args)
        {
            #region Sub Query Instance

            TestSubQuery();
            
            #endregion

            #region 创建查询策略(链式编程原理 ：将复杂任务分解成若干个小步骤完成。)

            LinkProgram();
            
            #endregion

            Console.ReadKey();

        }

        #region Test Sub Query

        //Linq to Objects :sub query 否决的：迭代外层循环时,子查询都会被执行一遍，效率低下
      
        //Linq to Provider:sub query 推荐用：这时候外层查询和子查询会被作为一个单元执行，即解析了lambda表达式树

        static void TestSubQuery()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            // 获取所有长度最短的名字（注意：可能有多个）
            IEnumerable<string> outQuery = names
                .Where(n => n.Length == names　　　　　// 感谢A_明~坚持的指正，这里应该为==

                    .OrderBy(n2 => n2.Length)
                    .Select(n2 => n2.Length).First());      // Tom, Jay"

            // 与上面方法语法等价的查询表达式
            IEnumerable<string> outQuery2 =
                from n in names
                where n.Length ==　　　　　　　　　　　　// 感谢A_明~坚持的指正，这里应该为==

                    (from n2 in names orderby n2.Length select n2.Length).First()
                select n;

            // 我们可以使用Min查询运算符来简化
            //重：因为外部范围变量在子查询的作用域内，所以我们不能再次使用n作为内部查询的范围变量。 看源码理解
            IEnumerable<string> outQuery3=
                from n in names
                where n.Length == names.Min(n2 => n2.Length)
                select n;
        }

        #endregion

        #region 创建查询策略：（其实就是链式编程 这也是linq框架的基本原理） 看两个例子

        static void LinkProgram()
        {
            #region 渐进式查询           
            
            //方法语法
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = names
                .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "")
                    .Replace("o", "").Replace("u", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);   // Result: Dck, Hrry, Mry

            //查询语法 完成上面的方法语法的时候只能分步进行：原因查询语法要求语句必须以select或者group结束
            //当然用子查询也可以完成
            IEnumerable<string> query2 =
               from n in names
               select n.Replace("a", "").Replace("e", "").Replace("i", "")
                   .Replace("o", "").Replace("u", "");

            query2 = from n in query2
                    where n.Length > 2
                    orderby n
                    select n;   // Result: Dck, Hrry, Mry      
            #endregion

            #region Into关键字：本质上还是一个查询
           
            //into 表面上看起来像是开启了一个新的查询，实际上并不是这样。查询语法编译器最终会编译成对应的方法语法，不过
            //查询语法中into前面的变量在后面是不可以使用的

            IEnumerable<string> queryInto =
               from n in names
               select n.Replace("a", "").Replace("e", "").Replace("i", "")
                       .Replace("o", "").Replace("u", "")
                   into noVowel
                   where noVowel.Length > 2
                   orderby noVowel
                   select noVowel;   // Result: Dck, Hrry, Mry

            //等效的方法语法:
            IEnumerable<string> queryInfo1 = names
                .Select(name => name.Replace("a", "").Replace("e", "").Replace("i", "")
                       .Replace("o", "").Replace("u", ""))
                .Where(name => name.Length > 2)
                .OrderBy(name => name);//here name must implemented the IComparable,IComaparable<T>接口
            //实际上查询语法在翻译成方法语法的时候编译器会在保证逻辑的情况下做一定得优化。

            //正则解决aeiou的替换工作。
            IEnumerable<string> queryInfo2 = names
                .Select(name => Regex.Replace(name, "[aeiou]", ""))
                .Where(name => name.Length > 2)
                .OrderBy(name => name);

            #endregion

            #region 投影:本质就是select返回能遍历匿名对象的序列
        
            var intermediate = from n in names
                               select new
                               {
                                   Original = n,
                                   Vowelless = Regex.Replace(n, "[aeiou]", "")
                               };
            IEnumerable<string> query5 = from item in intermediate
                                        where item.Vowelless.Length > 2
                                        select item.Original;

            #endregion

            #region let关键字：保持范围变量的同时引入新的查询变量
         
            //let关键字详解????内部原理详解
           
            var query6 = from n in names
                         let Vowelless = Regex.Replace(n, "[aeiou]", "")
                         from c in Vowelless
                         where c != 'a'
                         select c;
                        //where Vowelless.Length > 2
                        //select n;   //正是因为使用了let，此时n仍然可见

            #endregion

            Console.ReadKey();
        }       


        #endregion
    }
}
