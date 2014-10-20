using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonCaculator
{
    /// <summary>
    /// 计算器的简单工厂类
    /// </summary>
    public static class CaculatorSimpleFactory
    {
        /// <summary>
        /// 返回计算器实例
        /// </summary>
        /// <param name="argOperator">用户操作符</param>
        /// <param name="argNum1">操作符1</param>
        /// <param name="argNum2">操作符2</param>
        /// <returns></returns>
        public static Caculator GetCaclulator(string argOperator, double argNum1, double argNum2)
        {
           
            //1根据用户操作符获取包含相应类型的计算器的dll名称，及类型完全限定名称
         
            string name= ConfigurationManager.AppSettings.Get(argOperator);

            string [] names= name.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

            string dllName = names[1];               //dll名称

            string typeFullName = names[0];          //类型的完全限定名

          
            //2获取配置文件指定的类型对象

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName);
         

            Assembly assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName));


            
            Type type = assembly.GetType(typeFullName);


            //3返回计算器实例
            return (Caculator) System.Activator.CreateInstance(type, new object[] {argNum1, argNum2});

        }
    }
}
