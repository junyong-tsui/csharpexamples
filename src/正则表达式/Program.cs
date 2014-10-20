using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace 正则表达式
{
    #region 正则表达式基本知识
    
    /* 基本概念:
     * 用来描述字符串特征的表达式
     * 特征:必须出现的内容,可能出现的内容,不能出现的内容
     * 步骤: 观察字符串规律，根据规律总结特征,然后根据特定字符串的特征来编写正则表达式
     */

    /*元字符:     * 
     * “.”    表示除\n之外的任意的单个字符
     * “[]”   匹配括号中的任意的一个字符 中间“-”表示出现字符的范围(a[0-9]b),“^”非的含义,表示不能出现的字符(a^[0-9]b)  
     * “|”    将两个匹配条件进行逻辑“或”运算      运算的优先级较低    
     * “()”   1提高优先级 2提取组
     * “*”    表示前面的表达式出现0次或多次 -------->限定符
     * “+”    表示前面的表达式出现1次或多次 -------->限定符
     * “？”   1表示前面的表达式出现0次或1次 -------->限定符  2终止贪婪模式(出现在其他限定符后面)
     * “{n}”  限定前面的表达式必须出现n次
     * “{n,}” 限定前面的表达式至少出现n次
     * “{n,m}”限定前边的表达式至少出现n次，最多出现m次
     * “^”    匹配字符串的开头  描述字符串开头必须满足的条件：描述字符串开始的特征
     * “$”    匹配字符串的结尾  描述字符串结尾必须满足的条件: 描述字符串结尾的特征
     * “\d”   等价于[0-9]表示匹配一个0到9的数字字符
     * “\D”   [^0-9]
     * “\s”   匹配所有的空白字符 即不可见字符
     * “\S”   [^\s] 
     * “\w”   [0-9a-zA-Z_汉字]
     * “\W”   [^0-9a-zA-Z_汉字] 
     * “\b”   表示单词的边界(断言,只判断,不匹配)     *  
     */

    //[\s\S],[\d\D],[\w\W]匹配所有的字符


    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            #region 27号作业  元字符熟悉及通用正则熟悉

            #region 1验证是否为身份证号码

            //do
            // {
            //     Console.WriteLine("请输入身份证号");

            //     string identifier = Console.ReadLine();

            //     bool isMatch = Regex.IsMatch(identifier, @"^(\d{15}|\d{17}[0-9xX])$");

            //     Console.WriteLine(isMatch);

            // } while (Console.ReadLine()!="Y");

            #endregion

            #region 判断是否正确的国内电话

            //do
            //{
            //    Console.WriteLine("请输入电话号码");

            //    string phoneNum = Console.ReadLine();

            //    bool isMatch = Regex.IsMatch(phoneNum,@"^(\d{3,4}\-?\d{7,8}\d{5})$",RegexOptions.IgnorePatternWhitespace);              

            //    Console.WriteLine(isMatch);

            //} while (Console.ReadLine() != "Y");

            #endregion

            #region 判断是否为邮件地址

            //do
            //{

            //    Console.WriteLine("请输入邮件地址");

            //    string emilAddress = Console.ReadLine();

            //    bool result = Regex.IsMatch(emilAddress, @"^[-0-9a-zA-z_.]+@[-0-9a-zA-z]+[-0-9-zA-z.]+$", RegexOptions.ECMAScript);

            //    Console.WriteLine(result);

            //} while (Console.ReadLine()!="Y");


            #endregion

            #region  从字符串中提取所有人名 提取组

            //            string str = @"大家好。我们是S.H.E。我是S。我是H。我是E。我是杨中科。我是苏坤。我是杨洪波。我是牛亮亮。我是N.L.L。
            //                   我是★蒋坤★。呜呜。fffff";

            //            MatchCollection names= Regex.Matches(str, @"我是(.+?)。");

            //            foreach (Match match in names)
            //            {
            //                Console.WriteLine(match.Groups[1]);
            //            }

            #endregion

            #region 将一段文本中的MM/DD/YYYY格式的日期转换为YYYY-MM-DD格式 ，比如“我的生日是05/21/2010耶”转换为“我的生日是2010-05-21耶”

            //string  msg=@"“我的生日是05/21/2010耶。";

            //string result = Regex.Replace(msg, @"(\d{2})/(\d{2})/(\d{4})","$3-$1-$2");

            //Console.WriteLine(result);


            #endregion

            #region  替换'。。。 '成[....]

            //string result = Regex.Replace("fdasfsa hello 'welcome' to 'china' fdsafsaf ", @"'(.+?)'", "[$1]");

            //Console.WriteLine(result);

            //Console.ReadKey();

            #endregion

            #region 替换手机号中的指定位置数字为*

            //string result1 = Regex.Replace(@"13456789043", @"(\d{3})\d+(\d{4})", "$1****$2");

            //Console.WriteLine(result1);

            #endregion

            #region 给一段文本中匹配到的url添加超链接，比如把http://www.test.com替换为<a href="http://www.test.com"> http://www.test.com</a>

            //使用字面量字符串时候时候"\"不表示一个转义含义 这时候两个双引号代表一个引号

            //string msg = "新浪的网址是：http://www.sina.com.cn搜狐的网址是：http://www.sohu.com还有网易的网址：http://www.163.com";

            //string result = Regex.Replace(msg, @"([0-9a-zA-Z]://[-0-9a-zA-Z_]+[-0-9a-zA-Z.]+(/[-0-9a-zA-z_./?%&=]*)?)", @"<a href=""$1"">$1</a>");

            //Console.WriteLine(result);

            //Console.ReadKey();

            #endregion

            #region 提取51job上【上海,IT-管理,计算机软件招聘，求职】-前程无忧.htm的职位信息

            //网页上链接的格式如：<a href="http://search.51job.com/job/46629381,c.html" onclick="zzSearch.acStatRecJob( 1 );" class="jobname" target="_blank">信息专员</a>

            //1根据网址下载对应的html字符串

            //string url = "http://192.168.1.52:8080/【上海,IT-管理,计算机软件招聘，求职】-前程无忧.htm";

            //var webClient = new WebClient();

            //string html = webClient.DownloadString(url);

            //2提取职位信息 

            //分析1 职位信息都包含在超链接里面 且链接中一定包含jobname,而其他链接基本不包含这个信息
            //MatchCollection matchs = Regex.Matches(html, @"<a\s+href=.+jobname.+>(.+)</a>");


            //分析2 职位信息都包含在超链接里面 且超链接内容固定，只有中间8位数字变化
            //MatchCollection matchs = Regex.Matches(html,@"<a href=""http://search.51job.com/job/\d{8},c.html"".+>(.+)</a>");

            //3遍历匹配输出提取组
            //foreach (Match match in matchs)
            //{
            //    Console.WriteLine(match.Groups[1]);
            //}

            //Console.WriteLine(matchs.Count);

            #endregion

            #region 提取Email.htm  通过WebClient下载

            //string url = "http://192.168.1.52:8080/提取Email.htm";

            //var webClient = new WebClient();

            //string html = webClient.DownloadString(url);

            //var matches = Regex.Matches(html, @"[-0-9a-zA-Z_.]+@([-0-9a-zA-Z]+[-0-9a-zA-Z.]+)");

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Groups[0]+"=========="+match.Groups[1]);
            //}

            //Console.WriteLine(matches.Count);

            //Console.ReadKey();


            #endregion

            #region 提取美女图片  通过WebClient下载


            ////1下载网页
            //string url = "http://localhost:8080/美女图片/美女们.htm";

            //var webClient = new WebClient();

            //string html = webClient.DownloadString(url);

            ////2提取图片路径
            //var matches = Regex.Matches(html, @"<img\s+alt=""""\s+src=""(.+)""\s+/>");


            ////3下载图片
            //foreach (Match match in matches)
            //{
            //    string path = "http://192.168.1.52:8080/美女图片/" + match.Groups[1].Value;

            //    webClient.DownloadFile(path,@"d:\img\"+Path.GetFileName(path));
            //}

            //Console.WriteLine(matches.Count);

            //Console.ReadKey();






            #endregion

            #region 抓取百度图片首页图片

            //1下载网页文本
            WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };

            string html = webClient.DownloadString("http://image.baidu.com/");


            //2提取匹配的图片url组  分析：总是提取图片的url所以正则结尾肯定是图片的格式名，然后url地址一定在双引号里面  ，这样可以一定程度防贪婪模式

            var matches = Regex.Matches(html, @"""(http:[-0-9a-zA-Z\+\.\\/=%]+?(jpg|gif))""");

            //3下载网页抓取的图片
            int count = 0;
            foreach (Match image in matches)
            {
                try
                {
                    Console.WriteLine(image.Groups[1].Value);

                    string path = image.Value.Contains(@"\") ? image.Groups[1].Value.Replace(@"\", string.Empty) : image.Groups[1].Value;

                    webClient.DownloadFile(path, @"d:\img\" + Path.GetFileName(path));
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    count++;
                }
            }

            //4输出抓取图片结果
            Console.WriteLine("网页上抓取的图片个数{0}", matches.Count);

            Console.WriteLine("下载失败图片个数{0}", count.ToString());


            #endregion

            #region 把一个字符串中的zxh@itcast.cn  agcdef@yahoo.com nihaomahaha@sina.com.com邮箱用户名全部替换成*;

            //string str = @"把一个字符串中的zxh@itcast.cn  agcdef@yahoo.com nihaomahaha@sina.com.com邮箱用户名全部替换成*";

            //str = Regex.Replace(str, @"([-0-9a-zA-Z_.]+)(@[-0-9a-zA-Z]+[-0-9a-zA-Z.]+)", c => new string('*', c.Groups[1].Value.Length) + c.Groups[2]);

            //Console.WriteLine(str);

            //Console.ReadKey();

            #endregion

            #endregion

            #region 字符串: 查找3个字母的单词 \b使用 //断言:只验证不消耗字符 \b位于\w与\W之间

            //str = "Hi,how are you?Welcome to our country!";

            //var matches = Regex.Matches(str, @"\b[a-zA-Z]{3}\b");

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Value);
            //}
            //Console.ReadKey();

            #endregion 反向引用  将"杨杨杨杨杨中中中中科科科科科"去除重复

            #region 28号作业  反向引用与Split用法

            #region 1将"杨杨杨杨杨中中中中科科科科科"变成"杨中科"

            //str = "杨杨杨杨杨中中中中科科科科科";

            //str = Regex.Replace(str, @"(.)\1+", "$1");

            //Console.WriteLine(str);

            #endregion

            #region 2将"我...我我..我我我我....爱爱爱..爱..爱...你你...你..你你你..."，变成"我爱你"

            //string str = "我...我我..我我我我....爱爱爱..爱..爱...你你...你..你你你...";

            //str = str.Replace(".", string.Empty);

            //str = Regex.Replace(str, @"(.)\1+", "$1");

            //Console.WriteLine(str);


            #endregion

            #region 3从【英汉词典TXT格式.txt】中，提取所有的带叠词的英文单词，比如sheep、tool、proof、queen、professor、zoo、eel...

            ////1读取文件返回字符串内容
            //string content = File.ReadAllText("英汉词典TXT格式.txt", Encoding.GetEncoding("gb2312"));

            ////2提取带叠词的英文单词
            //var words = Regex.Matches(content, @"[a-zA-Z]*?([a-zA-Z])\1[a-zA-Z]*");

            //StringBuilder sb=new StringBuilder();

            //foreach (Match item in words)
            //{
            //    sb.AppendLine(item.Value);
            //}

            //Console.WriteLine(sb.ToString());
            //Console.WriteLine(words.Count);

            //Console.ReadKey();
            #endregion

            #region 4从一段文本中提取所有的叠词：“浩浩荡荡、清清白白”、...AABB

            ////1读取文本字符串
            //string content = File.ReadAllText("叠词工具.txt", Encoding.GetEncoding("gb2312"));

            ////2提取叠词
            //var matches = Regex.Matches(content, @"(\w)\1(\w)\2");


            ////3显示提取的结果
            //StringBuilder sb=new StringBuilder();
            //foreach (Match item in matches)
            //{
            //    sb.AppendLine(item.Value);
            //}
            //Console.WriteLine(sb.ToString());
            //Console.WriteLine(matches.Count);

            #endregion

            #region 5Regex.Split();//使用正则表达式进行分割

            /*
             * 与string.Split()相比而言 Regex.Split()分隔时候分隔符为匹配正则的字符串，分隔时候产生的空字符串实体无法去除，其他
             * 与string的split方法基本一致。
             */

            //             string str = @"大家好。我们是S.H.E。我是S。我是H。哈哈哈哈，呵呵呵呵，您好我是E。我不开心呼呼我是杨中科。我是苏坤。我是杨洪波。我是牛亮亮。我是N.L.L。
            //                     我是★蒋坤★。呜呜。fffff";

            //             string[] matches = Regex.Split(str, @"我是.+?。");

            //             foreach (string match in matches)
            //             {
            //                 if (string.IsNullOrEmpty(match))
            //                 continue;
            //                 Console.WriteLine(match);
            //             }

            //            Console.ReadKey();

            #endregion

            #region 6UBB=>html


            //            string ubb = @"【你好，我发现一个[b]新网站[/b]，[b]大家[/b]来看呀[url=http://www.qq.com]秋秋[/url]，
            //            另外一个有时间也可以看看[url=http://www.rupeng.com]如鹏[/url]，还有[url=http://www.itcast.cn]传智播客[/url]】。吼吼！";

            //            ubb = Regex.Replace(ubb, @"\[b\](.+?)\[/b\]", "<b>$1</b>");


            //            ubb = Regex.Replace(ubb, @"\[url=(.+?)\](.+?)\[/url\]", "<a href=\"$1\">$2</a>");


            //            Console.WriteLine(ubb);

            #endregion

            #region 7匿名委托与lambda表达式练习

            /*
             hisotry:命名方法=》匿名方法=》lambda表达式 主要是对只使用一次的方法的封装,语法糖，编译器按照匿名方法，lambda表达式语法
             * 解析生成相应的静态委托变量及静态方法 =>优雅编程
             */

            #region 1无参数及返回值

            ////匿名方法
            //Action a = delegate(){ Console.WriteLine("我是一个无参数无返回值的匿名方法"); };
            //a();//=>a.Invoke();

            ////Lambda表达式
            //a = ()=>Console.WriteLine("我是一个无参数无返回值的Lambda表达式");
            //a();//=>a.Invoke();

            //Console.ReadKey();

            #endregion

            #region 2有一个参数无返回值

            ////匿名方法
            //Action<int> a = delegate(int x) { Console.WriteLine("我是有一个参数无返回值的匿名方法{0}", x.ToString()); };

            //a(10);//=>a.Invoke();

            ////Lambda表达式
            //a = (x) => Console.WriteLine("我是有一个参数无返回值Lambda表达式{0}", x.ToString());
            //a(20);//=>a.Invoke();

            //Console.ReadKey();

            #endregion

            #region 3有两个参数一个返回值

            //Func<int, int, string> a = delegate(int x, int y) { return (x + y).ToString(); };
            //Console.WriteLine("我是有两个参数一个返回值的匿名方法{0}", a(10, 20));


            //a = (x, y) => (x + y).ToString();
            //Console.WriteLine("我是有两个参数一个返回值的Lambda表达式{0}", a(30, 20));

            #endregion

            #endregion

            #region 8预习:委托与事件区别

            /*
             * 1委托:是一种数据类型，一个编译器生成的类(引用类型),是方法的包装器，使得方法
             * 作为参数类型安全的传递。另一方面委托可以匹配与其定义方法返回值和参数个数及类型的所有
             * 方法，那么使用委托本身就是一种多态，可以写出通用的代码，将变化的部分用委托封装出去。
             * ？封装变化：委托与事件的区别？何时使用？
             * 
             * 2事件:含义是事件的发布者发生了某件事情用来通知事件的订阅者的过程的一种机制,事件的引起
             * 可能是用户交互产生(鼠标，键盘操作产生)，也可以是程序逻辑引起(比如asp.net webform页面生命周期)。
             * 
             * 事件的实现基于委托：委托是实现事件的机制，这是由于委托充当了一个中间媒介，即：
             * 事件发布者是通过委托项事件订阅者通知的。
             * 
             * 事件内部实现上实际上是对委托的封装，可以看成是委托的“属性”,保证了事件的注册以及
             * 引发的安全性(即：订阅者不会无缘无故被取消或通知不到)。
             *
             * 定义一个事件的时候：编译器会生成一个私有的委托变量，并生成对应的Add,Remove方法，
             * 诸多注册、取消事件都是调用add,remove方法，(C#这里提供了语法糖)
             * 
             */
            #endregion

            #endregion

            #region 零宽断言经典例子  只匹配位置 不消耗字符

            #region 1(?=exp)零宽度正向预测先行断言 返回表达式前面部分  搜索方向 左到右 :===========》


            //重要点:断言仅匹配一个位置

            //string str = "abc";//断言只是匹配一个位置,并不占用匹配的字符

            //bool result = Regex.IsMatch(str, @"a(?=b)bc"); //a(?=b)#不消耗字符#c  false

            //Console.WriteLine(result);//true
 
            

            #endregion

            #region 2(?<=exp)也叫零宽度正回顾后发断言，它断言自身出现的位置的前面能匹配表达式exp  搜索方向 右左到 :《===========

            /*
             * 如定义所述：正则引擎解析的时候是从字符串的结尾处开始解析，根据正则表达式(?<=exp)exp后面的部分exp进行匹配，
             * 找到匹配后断言前面是否匹配(?<=exp)中定义的正则。 只匹配位置，不消耗字符、
             */

            //string str = "1234567890";

            //var matches = Regex.Matches(str, @"((?<=\d)\d{3})+\b");

            //str = Regex.Replace(str, @"((?<=\d)\d{3})+?", ",$1");

            //Console.WriteLine(str);

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Value);
            //}

            #endregion

            #region 3(?!exp) 零宽度负向预测先行断言  这个和零宽度正向预测先行断言区别在于:断言不能有匹配exp的内容

            //\d{3}(?!\d)        匹配三位数字 后面不能为数字

            //\b((?!abc)\w)+\b   匹配不包含连续字符串abc的单词。

            #endregion

            #region 4(?<!exp) 零宽度负回顾后发断言，与零宽度正向预测后发断言的区别在于 ：断言不能有匹配ex屁的内容



            
            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}
