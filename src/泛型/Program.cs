using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 泛型
{
    //泛型本质上是算法重用
    /* 1泛型内部原理简介
       泛型类均是开放类型，也就是定义的泛型类,是不能创建开放类型的实例的，因为它无法知道类型参具体类型(仅存活于dll,exe中)   * 
     * 封闭类 ：是指使用泛型类(开放类型)的时候传递的类型参数，以此封闭该开放类型，这样就能创建相应封闭类型的
     * 实例了，编译器对泛型类做了特出处理，将其编译成一些标记，CLR即时编译的时候翻译成具体类型加载到应用
     * 程序域中,然后就能创建其相应的实例了
     */

    /*2泛型的范围
     * 泛型类，泛型方法，泛型委托，泛型接口,泛型结构
     */

    /*
      泛型类在使用的时候只能用其封闭类型
     */

    class Program
    {
        private static void Main(string[] args)
        {
            //int封闭了泛型类GenericClass ， 通过数值23封闭了泛型方法GetValue 其实是语法糖
            GenericClass<int>.GetValue(23);

            // Gets the open generic method type
            // Notes, we should specify the class type T first.
            MethodInfo openGenericMethod = typeof(GenericClass<>).GetMethod("GetValue");

            // Gets the close generic method type, by supplying the generic parameter type
            MethodInfo closedGenericMethod = openGenericMethod.MakeGenericMethod(typeof(int));

            object o2 = closedGenericMethod.Invoke(null, new object[] { 20120929 });

            Console.WriteLine("o2 = {0}", o2.ToString());

            Console.ReadKey();

            // OUTPUT:
            // True
            // True
            // True
            // True
        }
    }

    #region 泛型类型

    //约束条件只能为T的父类,接口,new()：要求T具有无参的构造函数

    class MyClass<T>
    {
        private T[] _arr;

        public MyClass(params T[] arr)
        {
            _arr = arr;
        }

        public void ShowData()
        {
            foreach (T item in _arr)
            {
                Console.WriteLine(item);
            }
        }
    }

    class GenericClass<T>
    {
        private T _t = default(T);

        /// <summary>
        /// 只读的类型为T的属性Value
        /// </summary>
        public T Value
        {
            get
            {
                Console.WriteLine(typeof(T).FullName, _t.ToString());
                return _t;
            }
        }


        public GenericClass(T argT)
        {
            _t = argT;
        }

        //
        public static U GetValue<U>(U u)
        {
            Console.WriteLine("StaticGetValue<{0}>( {1} ) method invoked",
                typeof(U).FullName, u.ToString());
            return u;
        }

    }

    #endregion

    #region 泛型结构

    struct MyStruct<T> where T : struct
    {

    }

    #endregion

    #region 泛型方法 其实就是参数和返回值用类型占位符 其中类型占位符可以加约束

    class Person
    {
        //public T A { get; set; }

        /// <summary>
        /// 调用方法时候可以隐士类型推断  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        public void Show<T>(T msg) where T : IComparable
        {
            Console.WriteLine(msg);
        }
    }

    #endregion

    #region 泛型接口  行为抽象，适用于多种类型

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>翻译器接口
    //internal interface ITranslator<T> where T : new()
    //{
    //    T WordDictionary { get; set; }
    //}

    internal interface ITranslator<T>
    {
        T WordDictionary { get; set; }
    }

    internal abstract class Translator<TYzk, V> : ITranslator<TYzk>
        where TYzk : new()
        where V : class
    {

        public TYzk WordDictionary
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }



    #endregion

    #region 泛型委托 不需要自己定义，使用系统的，这是规范化的标准

    public delegate T Fuck<T>(T obj);

    #endregion

    #region 泛型类型的反射

    #endregion

    #region 扩展方法
    
    /*三要素：
     *       1静态类
     *       2静态方法
     *       3this关键字 表名对谁扩展
     * */

    /// <summary>
    /// 字符串的扩展类
    /// </summary>
    public static class StringExtention
    {
        public static bool IsEmail(this string obj)
        {
            return Regex.IsMatch(obj, @"^\w+@\w+\.\w+$");
        }
    }

    /// <summary>
    /// List集合的扩展类
    /// </summary>
    public static class ListExtension
    {
        public static List<T> MyWhere<T>(this List<T> lst, Func<T, bool> predidate) where T:class
        {
            List<T> list = new List<T>();
            foreach (var item in lst)
            {
                if (predidate(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    
    }

    #endregion


}
