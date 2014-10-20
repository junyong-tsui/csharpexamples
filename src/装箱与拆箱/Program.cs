using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013_09_23_课堂演练
{
    class Program
    {
        static void Main(string[] args)
        {
            //装箱：把值类型转换为引用类型(System.Object,或者值类型实现的接口)
          
            // 值类型继承自System.Object,及实现的接口 所以装箱后的对象只能为 值类型继承的父类，及实现的接口: System.Object及其实现的接口  
         
            //只是编辑器优化处理不需要实现显示隐士类型转换，直接用Box,UnBox指令完成这些操作
            
            //int b = 10;
            //double d = n;//没有发生装箱,值类型的隐士转换
            //Console.WriteLine(d);

            //int n = 10;
            //string s = n.ToString(); string与Int32类型之间没有任何
            //Console.WriteLine(s);


            //int b = 10;
            //object d = b; //装箱 int=>object System.Int32实例给d
            //Console.WriteLine(d);


            //int b = 10;
            //IComparable c = b;  //装箱 int=>object System.Int32实例给c
            //Console.WriteLine(c.CompareTo(5));

            //拆箱:把装箱后的对象转换为值类型(与转换前的类型要一致)
                 
                   //根据装箱后的对象引用 找到装箱的值=》也就是地址计算的过程=>拆箱

                   //但一般伴随着将值赋值到栈上

            double d = 90;

            object o = d;      //装箱 Box:类似于转父

            int b = (int) o;   //拆箱 UnBox:类似于父转子   拆箱时候 拆箱后值类型的与装箱前的值类型要对应


            Console.WriteLine();


            #region 装箱拆箱性能问题

            ArrayList array=new ArrayList();
            Stopwatch watch=new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                array.Add(i);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);



            List<int> list = new List<int>();
            watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);


            #endregion


            /*
             判断依据      
             * 装箱：值类型=》object,或者值类型实现的接口类型
             * 拆箱: object,或者值类型实现的接口类型=》装箱前的值类型
             *///注意：装箱前后类型一致性。


            #region 案列

            #region 1

            int n = 10, m = 100;
            string  s = "a";


            #region 字符串采用"+"拼接时候的装箱  内部调用 String.Concat方法

            //若果不同类型混合则参数最终会转换为Object，同类型的字符串则都为不转换类型

            string s1 = n + s + m;    //是否装箱，装箱次数     装箱,内部调用String.Concat(object, object, object)方法   2次 避免装箱应调用值类型的ToString()方法

            string s2 = n + m + s;    //是否装箱，装箱次数      装箱,内部调用String.Concat(object,object)方法   1次 会先计算n+m的值再装箱 编译器优化处理

            string s5 = s + "djasfkdsa";                  //这个时候一般调用String.Concat(string,string) 方法

            
            #endregion

            #region 复合格式字符串，对象参数列表中的值类型会装箱

            Console.WriteLine("{0}", m);             //是否装箱      装箱 

            string s4 = string.Format("{0}", n + m);//是否装箱      装箱 

            #endregion

            Console.WriteLine(n);  //是否装箱               不会装箱，使用的是重载版本的方法,不用装箱。

            #endregion

            #endregion


            string path = @"D:\aa\bb";

          

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);//true表示删除同时删除目录下所有的目录及文件
                    
                }
                catch (Exception err)
                {

                    Console.WriteLine(err.Message);
                }
               
            }

            Console.ReadKey();
        }
    }
}
