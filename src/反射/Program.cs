using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 反射
{
    /*
     * 程序集: 是CLR 加载、部署、发布、安全管理、版本控制的基本单元（CLR不能直接加载模块 可以加载主模块）
     *         由一个或多个模块组成(需使用工具生成多模块程序集)
     *   模块: 由元数据(包含类型、方法、参数的定义)，IL, 资源文件(string blobs,二进制位图等)组成。   
     *   
     * 反射:通过动态获取程序集，并获取其中的类型元数据,然后访问
     */
    class Program
    {
        static void Main(string[] args)
        {

            const string dllPath = @"F:\黑马教学资料\CSharp知识点总结\反射测试的dll\bin\Debug\反射测试的dll.dll";


            //
            Assembly assembly = Assembly.LoadFile(dllPath);//路径要求全路径


            #region 反射测试dll中包含的类型


            //foreach (Type exportedType in assembly.GetExportedTypes())
            //{
            //    Console.WriteLine(exportedType.ToString());
            //}


            //Module[] modules = assembly.GetModules();

            //foreach (Module module in modules)
            //{
            //    Console.WriteLine(module.ToString());
            //}


            //var  moduleList = assembly.Modules;



            //foreach (Module module in moduleList)
            //{
            //    Console.WriteLine(module.ToString());
            //}


            //moduleList=assembly.GetLoadedModules();

            //foreach (Module module in moduleList)
            //{

            //    Console.WriteLine(module.ToString());
            //}




            #endregion

            #region 反射测试创建类型的对象  通过构造函数或者Activator的CreateInstance完成

            Type personType = assembly.GetType("反射测试的dll.Person");

            #region 1构造器创建类的实例

            ////用于获取带参数的构造器
            //ConstructorInfo constructor =
            //    personType.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });
            //var obj = constructor.Invoke(new object[] { "gzr", 24, "sxdxgzr@126.com" });

            //Console.WriteLine(obj.ToString());

            #endregion

            #region 2  系统激活器创建类的实例


            object obj = System.Activator.CreateInstance(personType);


            Console.WriteLine(obj.ToString());

            #endregion

            #region 类型方法句柄唯一及成员信息对象缓存机制测试

            //ConstructorInfo constructor1 =
            // personType.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            //由于类型对象在内存中只会有一份内存，也就意味着所有成员的句柄只会有一份，我们通过type的方法获取成员返回的是成员句柄的封装实例,此实例会被cl缓存下来

            //Console.WriteLine(constructor.MethodHandle.Value==constructor1.MethodHandle.Value);

            //Console.WriteLine(constructor==constructor1);

            ////用于获取不带参数的构造器
            //ConstructorInfo noparamConstructorInfo = personType.GetConstructor(new Type[] {});

            ////用于获取不带参数的构造器
            //ConstructorInfo noparamConstructorInfo1 = personType.GetConstructor(new Type[] { });

            #endregion

            #endregion

            #region 反射测试类型的属性

            PropertyInfo namPropertyInfo = personType.GetProperty("Name");

            Console.WriteLine(namPropertyInfo.GetValue(obj, null));

            #endregion

            #region 反射测试类型的索引器

            #endregion

            #region 反射测试类型的方法

            MethodInfo methodInfo = personType.GetMethod("SayHello");

            methodInfo.Invoke(obj, null);

            #endregion

            #region 反射测试类型的接口   反射接口基本上没有任何意义 编程依赖于抽象，接口是中间组件用于解耦

            //Type flyable = assembly.GetType("反射测试的dll.IFlyable");

            //Console.WriteLine(flyable);

            //Type surperType = assembly.GetType("反射测试的dll.SuperMan");

            //InterfaceMapping mapping= surperType.GetInterfaceMap(flyable);

            //var jj= flyable.GetConstructors();

            //MethodInfo kk = flyable.GetMethod("Fly");

            //kk.Invoke(System.Activator.CreateInstance(surperType), null);

            #endregion

            #region 反射测试类型的事件


            Type alarmType = assembly.GetType("反射测试的dll.Alarm");

            ConstructorInfo[] constructorInfos = alarmType.GetConstructors();


            var paramss = constructorInfos[0].GetParameters();



            var program = new Program();
            obj = constructorInfos[0].Invoke(new object[] { program, program.GetType().GetMethod("Hello").MetadataToken });


            MethodInfo methodInfo1 = alarmType.GetMethod("Invoke");
            methodInfo1.Invoke(obj, null);

            #endregion

            Console.ReadKey();
        }


        private static void Hello()
        {
            Console.WriteLine("hell0 ,fjffsjljfsljlljjdfjl");
        }
    }

    class TypeDemo
    {
        /// <summary>
        /// IsAssignableFrom:当前类型变量是否可以指向c的实例
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        //public virtual bool IsAssignableFrom(Type c)
        //{
        //    c类型对象为null
        //    if (c == null)
        //    {
        //        return false;
        //    }
        //    if (this != c)
        //    {
        //        RuntimeType underlyingSystemType = this.UnderlyingSystemType as RuntimeType;
        //        if (underlyingSystemType != null)
        //        {
        //            return underlyingSystemType.IsAssignableFrom(c);
        //        }
        //        c是否是当前类型的子类：根据basetype向上查找
        //        if (c.IsSubclassOf(this))
        //        {
        //            return true;
        //        }
        //        c类型及其上级类型中是否实现了当前接口
        //        if (this.IsInterface)
        //        {
        //            return c.ImplementInterface(this);
        //        }
        //        if (!this.IsGenericParameter)
        //        {
        //            return false;
        //        }
        //        Type[] genericParameterConstraints = this.GetGenericParameterConstraints();
        //        for (int i = 0; i < genericParameterConstraints.Length; i++)
        //        {
        //            if (!genericParameterConstraints[i].IsAssignableFrom(c))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //whether this or the uplever class of this have implemented the ifaceType
        //internal bool ImplementInterface(Type ifaceType)
        //{
        //    for (Type type = this; type != null; type = type.BaseType)
        //    {
        //        Type[] interfaces = type.GetInterfaces();
        //        if (interfaces != null)
        //        {
        //            for (int i = 0; i < interfaces.Length; i++)
        //            {
        //                if ((interfaces[i] == ifaceType) || ((interfaces[i] != null) && interfaces[i].ImplementInterface(ifaceType)))
        //                {
        //                    return true;
        //                }
        //            }s
        //        }
        //    }
        //    return false;
        //}
    }
}