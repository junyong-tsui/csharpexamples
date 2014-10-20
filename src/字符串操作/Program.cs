using System;
using System.IO;
using System.Text;

namespace 字符串练习
{
    class Program
    {
        static void Main(string[] args)
        {

            //#region 练习1

            //Console.WriteLine(ReverseString("abc"));
            
            //#endregion

            //#region 练习2

            //Console.WriteLine(Reverse("I love you"));

            //#endregion

            //#region 练习3

            //string[] result = GetNumInDate("2012年12月21日");

            //Console.WriteLine(string.Join("/", result));

            //#endregion

            //#region 练习4


            //Console.WriteLine(GetInfoFromCsv());

            //#endregion

            //#region 练习5

            //Console.WriteLine(RemoveSpecificSymbol("123-456---7---89-----123----2"));

            //#endregion

            //#region 练习6

            //Console.WriteLine(GetFileName(@"c:\a\b.txt"));

            //#endregion

            //#region 练习7

            //Console.WriteLine(ParseIp(@"192.168.10.5[port=21,type=ftp]"));

            //Console.WriteLine(ParseIp(@"192.168.10.5[port=80]"));

            //#endregion

            //#region 练习8

            //PrintEmployeSalary();

            //#endregion


            //#region 练习9

            //Console.WriteLine("传智播客出现次数{0}", CountSpecificWord("北京传智播客软件培训，传智播客.net培训，传智播客Java培训。传智播客官网：http://www.itcast.cn。北京传智播客欢迎您。"));

            //#endregion


            Console.ReadKey();
        }

        #region 练习1

        /*
         * 接收用户输入的字符串，将其中的字符以与输入相反的顺序输出。"abc"→"cba“.
         */
      
        private static string ReverseString(string argSrc)
        {
            char[] dest = argSrc.ToCharArray();

            for (int i = 0; i < dest.Length/2; i++)
            {
                char tem = dest[i];
                dest[i] = dest[dest.Length - 1 - i];
                dest[dest.Length - 1 - i] = tem;
            }

            return new string(dest);
        }


        #endregion

        #region 练习2

        /*
         
         * 接收用户输入的一句英文，将其中的单词以反序输出。      “I love you"→“I evol uoy"
         
         */

        private static string Reverse(string argSrc)
        {
            string[] srvc = argSrc.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < srvc.Length; i++)
            {
                srvc[i] = ReverseString(srvc[i]);
            }

            return string.Join(" ", srvc);
        }

        #endregion

        #region 练习3

        /*”2012年12月21日”从日期字符串中把年月日分别取出来，打印到控制台*/

        /// <summary>
        /// 返回日期中的数字字符串
        /// </summary>
        /// <param name="argDate">日期的字符串表示形式</param>
        /// <returns>int[] 日期数字数组</returns>
        static string[] GetNumInDate(string argDate)
        {
            return argDate.Split(new[] {'年','月','日'},StringSplitOptions.RemoveEmptyEntries);
        }


        #endregion

        #region 练习4


        /*
         把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：
  姓名：张三  电话：15001111113        原格式："张","三","15011111111"
         */

        /// <summary>
        /// 从csv文件获取指定格式的内容
        /// </summary>
        /// <returns></returns>
        static string GetInfoFromCsv()
        {
           string[] content= File.ReadAllLines("1.csv", Encoding.Default);
           for (int i = 0; i < content.Length; i++)
           {

               string[] strs = content[i].Split(new[] { '"', ','}, StringSplitOptions.RemoveEmptyEntries);

               content[i] = "姓名：" + strs[0] + strs[1] + "  " + "电话：" + strs[2]+Environment.NewLine;
           }
          
           return string.Concat(content);
        }


        #endregion

        #region 练习5

        /*
         123-456---7---89-----123----2把类似的字符串中重复符号”-”去掉，既得到123-456-7-89-123-2. split()、StringSplitOptions.RemoveEmptyEntries   Join()         
         */
        /// <summary>
        /// 移除指定符号
        /// </summary>
        /// <returns></returns>
        static string RemoveSpecificSymbol(string argSource)
        {
            return string.Join("-", argSource.Split(new[]{'-'}, StringSplitOptions.RemoveEmptyEntries));
        }


        #endregion

        #region 练习6

        /*
         * 
         * 从文件路径中提取出文件名(包含后缀) 。比如从c:\a\b.txt中提取出b.txt这个文件名出来。以后还会学更简单的方式：“正则表达式”，项目中我们用微软提供的：Path.GetFileName();（更简单。）
         * 
         */

        private static string GetFileName(string argFileFullName)
        {
            return argFileFullName.Substring(argFileFullName.LastIndexOf(@"\",StringComparison.Ordinal)+ 1);
        }






        #endregion

        #region 练习7

        /*
         “192.168.10.5[port=21,type=ftp]”，这个字符串表示IP地址为192.168.10.5的服务器的21端口提供的是ftp服务，其中如果“,type=ftp”部分被省略，则默认为http服务。请用程序解析此字符串，然后打印出“IP地址为***的服务器的***端口提供的服务为***” line.Contains(“type=”)。192.168.10.5[port=21]         
         */

        /// <summary>
        /// 转换IP
        /// </summary>
        /// <param name="argSrc">原字符串</param>
        /// <returns></returns>
        private static string ParseIp(string argSrc)
        {
            string[] strs = argSrc.Split(new[] {"[port=", ",type=","]"}, StringSplitOptions.RemoveEmptyEntries);
            
            return string.Format(@"IP地址为{0}的服务器的{1}端口提供的服务为{2}", strs[0], strs[1], strs.Length ==2 ? "Http":strs[2]);
        }

        #endregion

        #region 练习8


        /*
         求员工工资文件中，员工的最高工资、最低工资、平均工资*
         */
        /// <summary>
        /// 打印员工的最高工资，最低工资，平均工资
        /// </summary>
        static void PrintEmployeSalary()
        {
            string[] employees = File.ReadAllLines("salary.txt", Encoding.Default);

            int count = 0;//员工个数
            string maxSalaryName = string.Empty;//最大薪酬员工
            double maxSalary =0;//最高工资
            string minSalaryName = string.Empty;//最小薪酬员工
            double minSalary = int.MaxValue;//应该工资没有比这个的小
            double sumSalary = 0;//平均工资

            foreach (string employee in employees)
            {
                string[] emoloyessInfo = employee.Split(new []{'='}, StringSplitOptions.RemoveEmptyEntries);
                if (emoloyessInfo.Length == 0) continue;

                int employeeSalary = Convert.ToInt32(emoloyessInfo[1]);
                
                //查找工资最高员工
                if (employeeSalary>maxSalary)
                {
                    maxSalary = employeeSalary;
                    maxSalaryName = emoloyessInfo[0];
                }

                //查找工资最低员工
                if (employeeSalary<minSalary)
                {
                    minSalary = employeeSalary;
                    minSalaryName = emoloyessInfo[0];
                }

                sumSalary += employeeSalary;
                count++;
            }

            if (count==0)
                     Console.WriteLine("没有员工的记录信息");
            else
                Console.WriteLine("员工最高工资{0},最低工资{1}，平均工资{2}",maxSalary,minSalary,sumSalary*1.0/count);

        }

        #endregion

        #region 练习9

        /*
         * “北京传智播客软件培训，传智播客.net培训，传智播客Java培训。传智播客官网：http://www.itcast.cn。北京传智播客欢迎您。”。在以上字符串中请统计出”传智播客”出现的次数。找IndexOf()的重载。
         */


        private static int CountSpecificWord(string argSrc)
        {
            string word = "传智播客";
            int count = 0;
            int index = 0;
            while ((index=argSrc.IndexOf(word,index,StringComparison.Ordinal))!=-1)
            {
                count++;
                index = index + word.Length;
            }

            return count;
        }


        #endregion
    }
}


/*
 * Ctrl+R,M  extract Method
 * Ctrl+R,E  Extract Property
 * Ctrl-,f12 backword,forword
 * ctor  tab 2 constructor
 * cw console.writeline
 * alt +上，下  上下方法
 * alt +insert 生成成员
 */
