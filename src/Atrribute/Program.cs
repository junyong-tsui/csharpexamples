using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 反射测试的dll;

namespace Atrribute
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 自定义正则验证器特性测试

            User user = new User() { Name = "gzr", Email = "sxdxgzr@vip.qq.com", PostCode = "421300" };

            Console.WriteLine(Validate(user) ? "是合法用户" : "非法的用户");
            
            #endregion

            #region 索引测试

            Person p=new Person("gzr",24,@"sxdxgzr@126.com");

            foreach (PropertyInfo propertyInfo in p.GetType().GetProperties())
            {
                //非索引化属性跳过
                if (propertyInfo.GetIndexParameters().Length == 0) ;            

                Console.WriteLine(propertyInfo.GetValue(p, new object[]{3}));   
            }

            #endregion

            Console.ReadKey();
        }     

        /// <summary>
        /// 校验用户的信息是否合法
        /// </summary>
        /// <returns></returns>
        private static bool Validate(User user)
        {
            foreach (PropertyInfo propertyInfo in user.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType!=typeof(string)) continue;
               
                //获取应用了RegexValidatorAtrribute特性的属性的特性
                var customAttribute = propertyInfo.GetCustomAttribute<RegexValidatorAtrribute>();     
          
                //
                if (customAttribute!=null)
                {
                    
                    bool match= Regex.IsMatch(propertyInfo.GetValue(user, null).ToString(), customAttribute.RegexPattern);

                    //customAttribute.ErrorMsg
                    if (!match) return match;
                }
            }

            return true;
        }
    }


    /// <summary>
    /// 人员类
    /// </summary>
    public class User
    {
        public string Name { get; set; }

        //命名参数:意味着特性的属性可以以命名参数的方式赋值
        [RegexValidatorAtrribute(@"^\w+@\w+[\.\w]+$", ErrorMsg = "输会输入吗")]           //[]中的元字符\d,\w,\s等若要表示字符还需要转义才可
        public string Email { get; set; }

        [RegexValidatorAtrribute(@"^\d{6}$")]
        public string PostCode { get; set; }
    }

}
