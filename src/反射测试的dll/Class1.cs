using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射测试的dll
{

    #region 反射测试的类型、属性、索引器、方法、泛型类型

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public Person()
        {

        }

        public Person(string argName, int argAge, string argEmail)
        {
            Name = argName;
            Age = argAge;
            Email = argEmail;
        }

        public object this[string name]
        {
            get
            {
                if (name=="Name")
                {
                    return Name;
                }

                if (name == "Age")
                {
                    return Age;
                }

                if (name == "Email")
                {
                    return Email;
                }

                throw new Exception("参数异常");
            }
            set
            {
                if (name == "Name")
                {
                     Name=(string)value;
                }

                if (name == "Age")
                {
                     Age=(int)value;
                }

                if (name == "Email")
                {
                     Email=(string)value;
                }

            }
        }

        public void SayHello()
        {
            Console.WriteLine("hello,welcome to the clr world");
        }
    }


    public class AddCaculator
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Add(params  int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
    }

    #endregion

    #region 反射测试的委托

    public delegate void Alarm(object sender, EventArgs args);

    #endregion

    #region 反射测试的接口

    public interface IFlyable
    {
        void Fly();
    }


    public class SuperMan : IFlyable
    {

        public void Fly()
        {
            Console.WriteLine("飞人飞行");
        }
    }


    #endregion

    #region 反射测试的特性

    /// <summary>
    /// 只能应用于属性的正则验证器特性
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property)]
    public class RegexValidatorAtrribute : Attribute
    { 
        private string _regexPattern;
        /// <summary>
        /// 校验应用于属性的正则表达式
        /// </summary>
        public string RegexPattern
        {
            get
            {
                return _regexPattern;
            }
      
            private set
            {
                _regexPattern = value;

            }
        }

     
        /// <summary>
        /// 校验后的错误信息
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regexPattern">校验的正则</param>
        public RegexValidatorAtrribute(string regexPattern)
        {
            RegexPattern = regexPattern;
        }
    }     
   
    #endregion

}
