using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 作业
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 练习1

            //* 
            // *    
            // * 自己写一个student类，他有年龄，姓名，身高，3个属性，要求这个类实现Icomparable接口默认年龄升序排序，然后写几个比较器，按照姓名字母降序，按照姓名的字符长度排序，按照身高升序排序。3个比较器，每个比较器必须实现Icomparer接口，然后放到ArrayList集合中测试。     
            //*/

            var arr = new ArrayList()
            {
                new Student("abcfjdsklf",10,100),
                new Student("bcdfdsf",50,109),
                new Student("cdefsf",20,190),
                new Student("defdfsaf",60,90),
            };


            Console.WriteLine("=================按年龄升序排序==================");
            arr.Sort();
            OutputStudent(arr.ToArray());

            Console.WriteLine("=================按名称字母降序排序===============");
            arr.Sort(new StudentCompareByName());
            OutputStudent(arr.ToArray());

            Console.WriteLine("=================按名称长度升序排序===============");
            arr.Sort(new StudentCompareByNameLength());
            OutputStudent(arr.ToArray());

            Console.WriteLine("=================按身高升序排序===============");
            arr.Sort(new StudentCompareByHeight());
            OutputStudent(arr.ToArray());

            #endregion

            #region 练习2

         
            //*========以下使用泛型List<T>做。                  
            // * 创建一个只能添加整数的集合
            // * 创建一个只能添加字符串类型的集合
            // * 创建一个只能添加Person类型的集合
            // * 分别调用Sort（）方法测试
            // * 分别调用Sort（）的第三个重载   
            // */



            //List<Person> persons=new List<Person>{new Person("a",10),new Person("b",100),new Person("c",50)};

            ////使用默认比较器进行比较 此时 会将元素转换为IComparable的实例进行比较
            //Console.WriteLine("-----------Person按照年龄升序比较------------------");
            //persons.Sort();
            //OutputPerson(persons);

            //Console.WriteLine("-----------Person按照年龄降序比较------------------");
            //persons.Sort(0,persons.Count,new PersonCompare());
            //OutputPerson(persons);



            ////使用默认比较器进行比较 此时会采用FastComparaInt比较器进行比较
            //List<int> nums=new List<int>{1,3,6,940,7,37,20,100};
            //nums.Sort();                                          
            //Console.WriteLine(string.Join(" ",nums));
            ////采用第三个重载方法做与person一样，这里不做了


            ////使用默认比较器进行比较 此时 会使用Compare<T>.Default 最终任然是CultuleInfo.ComparaInfo进行比较
            //List<string> strs=new List<string>{"a","b","d","e","f","g","h","l","k"};
            //strs.Sort();
            //Console.WriteLine(string.Join(" ",strs));
            ////采用第三个重载方法做与person一样，这里不做了

            #endregion
          
            #region 练习6

            Console.WriteLine("6数字转繁体数字");

            Console.WriteLine(ConvertToTraditionNum("1234567890998"));

            Console.WriteLine();


            #endregion

            #region 练习7

            Console.WriteLine("7统计字符串中字符出现的次数 不区分大小写");

            OutputCharDic(CaculateChars("Welcome ,to Chinaworld"));

            Console.WriteLine();

            #endregion

            #region 练习8
       
            Console.WriteLine();

            Console.WriteLine("8简体转繁体");

            Console.WriteLine(ConvertToTraditionWord("您好，欢迎来到北京，简体中文！"));

            Console.WriteLine();

            #endregion

            #region 练习9

            Console.WriteLine("");

            Console.WriteLine(ConvertToUniverseDate("二零一二年二月二十一日"));

            Console.WriteLine();

            #endregion

            #region Test

            #region 1测试父子类都实现同一接口(父类提供具体实现，子类只继承接口 不再提供实现) 类型转换的时候花的时间

            //00:00:00.0001452 00:00:00.0001380
            //00:00:00.0001883 之所以时间长 是由于查找方法表花的时间更长。(子类父类公用实现，但都标记实现了同一接口) 证明某个观点错误

            //Stopwatch watch = new Stopwatch();

            //watch.Start();
            //Chinese chinese = new Chinese("张三", 100);
            //IComparable a = chinese;
            //IComparable<Person> b = chinese;
            ////b.CompareTo()

            //watch.Stop();

            //Console.WriteLine(watch.Elapsed);

            #endregion

            #region  验证使用数组管理元素 调用的比较方法 区别于List<T>

            //ArrayList arrst = new ArrayList { new Person("a", 10), new Person("b", 100), new Person("c", 50) };
            //arrst.Sort();

            #endregion     

            #region foreach 迭代器副本地址测试

            //迭代器仅是对可迭代类型的封装，使得基于迭代器机制的遍历效率更高 ,所谓的内存副本指的是
            //每次迭代会把current值赋值给栈上的临时变量,因此不能直接对象遍历的当前对象直接复制，但是若果是
            //引用类型倒是可以通过引用找到其成员进行修改操作。

            //迭代器知识封装了原集合在

            //var arr1 = new List<int>() {1, 2, 3, 4}; 

            //foreach (int num in arr1)
            //{
            //    num =000
            //}
 

            //for (int i = 0; i < arr1.Count; i++)
            //{ 
            //    var item = arr1[i];
            //    Console.WriteLine(arr1[i]);
            //}



            #endregion

            #endregion

            Console.ReadKey();
        }

        #region 练习6

        /*
         把123转换为：壹贰叁。Dictionary<char,char>
         */

        /// <summary>
        /// 数字字符串转换为繁体一二三
        /// </summary>
        /// <param name="argSrc">数字字符串</param>
        /// <returns></returns>
        private static string ConvertToTraditionNum(string argSrc)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>()
            {
                {'0', '零'},
                {'1', '壹'},
                {'2', '贰'},
                {'3', '叁'},
                {'4', '肆'},
                {'5', '伍'},
                {'6', '陆'},
                {'7', '柒'},
                {'8', '捌'},
                {'9', '玖'},
            };

            char[] chars = argSrc.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (dic.ContainsKey(chars[i]))
                {
                    chars[i] = dic[chars[i]];
                }
            }
            return new string(chars);
        }

        #endregion

        #region 练习7

        /// <summary>
        /// 统计字符串中字符出现的次数 (字符不区分大小写)
        /// </summary>
        /// <param name="argSrc">统计的字符串</param>
        /// <returns>//Dictionary<char, int> 键值为字符串中出现的字符的大写形式，值为字符出现的次数</returns>
        private static Dictionary<char, int> CaculateChars(string argSrc)
        {

            char[] chars = argSrc.ToUpper().ToCharArray();

            Dictionary<char, int> charDic = new Dictionary<char, int>();

            foreach (char c in chars)
            {
                if (!char.IsLetter(c)) continue;

                if (charDic.ContainsKey(c)) charDic[c]++;

                else charDic.Add(c, 1);
            }
            return charDic;
        }

        private static void OutputCharDic(Dictionary<char, int> argDictionary)
        {
            foreach (var dicEntity in argDictionary)
            {
                Console.Write("{0} {1}  ", dicEntity.Key, dicEntity.Value);
            }
        }



        #endregion

        #region 练习8 简繁体转换

        /// <summary>
        /// 获取简体-繁体对照字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetTraditionaryDictionary()
        {
            Dictionary<string, string> traditionWordDic = new Dictionary<string, string>();
            string[] words = File.ReadAllLines("简体-繁体.txt", Encoding.Default);
            foreach (string word in words)
            {
                string[] wordEntity = word.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (wordEntity.Length != 2 || traditionWordDic.ContainsKey(wordEntity[0])) continue;
                traditionWordDic.Add(wordEntity[0], wordEntity[1]);
            }
            return traditionWordDic;
        }

        /// <summary>
        /// 简体转繁体
        /// </summary>
        /// <param name="argSrc"></param>
        /// <returns></returns>
        static string ConvertToTraditionWord(string argSrc)
        {
            var dic = GetTraditionaryDictionary();
            char[] chars = argSrc.ToCharArray();


            for (int i = 0; i < chars.Length; i++)
            {
                string str = chars[i].ToString();

                if (dic.ContainsKey(str))
                {
                    chars[i] = dic[str][0];
                }
            }

            return new string(chars);
        }

        #endregion

        #region  练习9 中文日期转换

        /*
        编写一个函数进行日期转换，将输入的中文日期转换为阿拉伯数字日期，比如：二零一二年十二月月二十一日要转换为2012-12-21。(处理“十”的问题：1.*月十日；2.*月十三日；3.*月二十三日；4.*月三十日；)4中情况对“十”的不同翻译。1→10；2→1；3→不翻译；4→0【年部分不可能出现’十’，都出现在了月与日部分。】
         */

        /// <summary>
        /// 中文日期转换为阿拉伯数字日期
        /// </summary>
        /// <param name="argChineseDate">中文日期</param>
        /// <returns></returns>
        private static string ConvertToUniverseDate(string argChineseDate)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>()
            {
                {'零', '0'},
                {'一', '1'},
                {'二', '2'},
                {'三', '3'},
                {'四', '4'},
                {'五', '5'},
                {'六', '6'},
                {'七', '7'},
                {'八', '8'},
                {'九', '9'},
            };

            string[] strs = argChineseDate.Split(new char[] { '年', '月', '日' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = 0; i < strs.Length; i++)
            {
                string str = strs[i];

                if (!str.Contains("十"))
                {
                    List<char> tem = new List<char>();

                    if (str.Length == 1)
                    {
                        tem.Add('0');
                    }

                    foreach (char c in str)
                    {
                        tem.Add(dic.ContainsKey(c) ? dic[c] : c);
                    }

                    result.Add(new string(tem.ToArray()));
                }
                else
                {
                    List<char> tem = new List<char>();

                    if (str.Length == 2)
                    {
                        //添加十位字符
                        if (str[0] == '十')
                        {
                            tem.Add('1');
                        }
                        else
                        {
                            tem.Add(dic.ContainsKey(str[0]) ? dic[str[0]] : str[0]);
                        }

                        //添加个位字符
                        if (str[1] == '十')
                        {
                            tem.Add('0');
                        }
                        else
                        {
                            tem.Add(dic.ContainsKey(str[1]) ? dic[str[1]] : str[0]);
                        }
                    }
                    else
                    {
                        tem.Add(dic[str[0]]); //添加十位字符

                        tem.Add(dic[str[2]]); //添加个位字符
                    }

                    result.Add(new string(tem.ToArray()));
                }
            }

            return string.Join("-", result);
        }

        #endregion

        #region Other

        /// <summary>
        /// 输出集合中的Student元素
        /// </summary>
        /// <param name="arr"></param>
        private static void OutputStudent(object[] arr)
        {
            foreach (Student stu in arr)
            {
                if (stu != null)
                {
                    Console.WriteLine("姓名:{0} 年龄:{1} 身高:{2}", stu.Name, stu.Age, stu.Height);
                }
            }
        }

        /// <summary>
        /// 输出集合中的Person 元素
        /// </summary>
        /// <param name="arr"></param>
        private static void OutputPerson(IEnumerable<Person> arr)
        {
            foreach (Person person in arr)
            {
                Console.WriteLine("姓名:{0} 年龄:{1}", person.Name, person.Age);
            }
        }

        #endregion
    }

    #region  排序  基于比较接口  IComparer,IComparer<T> 所定义的规则  涉及集合:数组,ArrayList,List<T>  其他集合而言没有任何意义。

    /*1要点:排序原理：
      
     * 一般调用Array的静态 Sort方法，但元素比较规则一定由实现了IComparer,IComparer<T>类定义 这里IComparer接口,IComparer<T>抽象了所有类型元素的比较规则 这里应用了接口，Array的Sort作为最底层的方法,元素比较时依赖于比较接口,这是多态的典型运用.系统中的其他接口  eg:, IFormattable, IConvertible, IComparable<T>, IEquatable<T> 等都是系统内置类型抽象出来的接口DIP，集合的一整套接口也是符合单一职责，等OO规则；。
     
      * 也就是说排序时候比较元素是调用实现IComparer的实例的int Compare(object x, object y);
      * 或IComparer<T>（T x,T y）实现
      
      * 当不传IComparer参数时候 默认使用Comparer.Default 这个是用来实现字符串的大小比较的(CompareInfo 由当前线程的区域信息提供) 只能提供字符串的基于区域的;比较,其他类型若想比较的话则必须实现IComparable接口,这样可以调用CompareTo实现比较   =》数组或ArrayList内部实现原理
     
      *当不传IComparer<T>参数时候 默认使用的是Comparer<T>.Default比较，若T实现了IComparable<T> 则转换为为IComparable<T>进行比较,
      *否则对象都是使用的ObjectComparer<T>进行比较, ObjectComparer<T>内部比较时候又是使用Comparer.Default进行比较   =>List<T>内部实现原理  
     
      *当传IComparer,IComparer<T>参数时候则按照 接口实现者的方式进行比较                      
    */



    /*2排序的默认实现：排序时候不传IComparer参数时候比较的规则源代码: 也正好验证前面所说的功能 当自定义类型进行默认实现的参考代码
  *  public int Compare(object a, object b)
 {
     if (a == b)
     {
         return 0;
     }
     if (a == null)
     {
         return -1;
     }
     if (b == null)
     {
         return 1;
     }
     if (this.m_compareInfo != null)
     {
         string str = a as string;
         string str2 = b as string;
         if ((str != null) && (str2 != null))
         {
             return this.m_compareInfo.Compare(str, str2);
         }
     }
     IComparable comparable = a as IComparable;
     if (comparable != null)
     {
         return comparable.CompareTo(b);
     }
     IComparable comparable2 = b as IComparable;
     if (comparable2 == null)
     {
         throw new ArgumentException(Environment.GetResourceString("Argument_ImplementIComparable"));
     }
     return -comparable2.CompareTo(a);
 }    
  */


    /*自定义类型来实现默认排序功能及实现Icomparer接口进行排序例子
     * 
     */


    /*数据结构:线性数据接口：线性表 逻辑上相邻 物理上也相邻 与数据结构中增删改表现行为一致
      ArrayList,List<T> 增、插入、删的时候 会重新创建object[],T[]数组来容纳新的数据，说白了 这就是其数组大小动态变化之原理。 
     * 插入、删除可能涉及元素的移动。
     */

    #region 练习1   用ArrayList或数组管理元素

    /* 
     *    
     * 自己写一个student类，他有年龄，姓名，身高，3个属性，要求这个类实现Icomparable接口默认年龄升序排序，然后写几个比较器，按照姓名字母降序，按照姓名的字符长度排序，按照身高升序排序。3个比较器，每个比较器必须实现Icomparer接口，然后放到ArrayList集合中测试。     
     */

    /// <summary>
    /// 学生类
    /// </summary>
    class Student : IComparable, IComparable<Student>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public double Height { get; set; }


        public Student(string argName, int argAge, double argHeight)
        {
            Name = argName;
            Age = argAge;
            Height = argHeight;
        }

        #region IComparable 接口实现


        /*
         * 当用数组来管理元素 排序不传IComparer参数时 调用此方法         
         */

        /// <summary>
        /// 按对象的年龄比较 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>当前对象年龄大则返回1，相等返回0，否则返回-1</returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is Student)) throw new ArgumentException("Argument Must Be Student");

            return CompareTo((Student)obj);
        }

        #endregion


        #region IComparable<Student>接口实现

        /*
         * 当用List<T>来管理元素 排序时不传IComparer<T>参数时 调用此方法         
        */

        public int CompareTo(Student other)
        {
            if (other == null) return 1;

            if (Age > other.Age) return 1;

            if (Age < other.Age) return -1;

            return 0;
        }

        #endregion
    }

    /// <summary>
    /// 按学姓名的字符长度比较
    /// </summary>
    class StudentCompareByNameLength : IComparer, IComparer<Student>
    {
        static readonly StudentCompareHelper _studentCompareHelper;

        static StudentCompareByNameLength()
        {
            _studentCompareHelper = new StudentCompareHelper();
        }


        /// <summary>
        /// 比较两个对象大小
        /// </summary>
        /// <param name="x">比较的第一个对象</param>
        /// <param name="y">比较的第二个对象</param>
        /// <returns>x is greater then y return 1;  x is less then y return  -1; ortherwise 0</returns>
        public int Compare(object x, object y)
        {
            return _studentCompareHelper.Compare(x, y, StudentCompareType.CompareByNameLengthAsc);
        }

        public int Compare(Student x, Student y)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 按姓名字母比较
    /// </summary>
    class StudentCompareByName : IComparer, IComparer<Student>
    {
        static StudentCompareHelper _studentCompareHelper;

        static StudentCompareByName()
        {
            _studentCompareHelper = new StudentCompareHelper();
        }

        /// <summary>
        /// 比较两个对象大小
        /// </summary>
        /// <param name="x">比较的第一个对象</param>
        /// <param name="y">比较的第二个对象</param>
        /// <returns>x is greater then y return 1;  x is less then y return  -1; ortherwise 0</returns>
        public int Compare(object x, object y)
        {
            return _studentCompareHelper.Compare(x, y, StudentCompareType.CompareByNameDesc);
        }

        public int Compare(Student x, Student y)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 按姓名的字符长度比较
    /// </summary>
    class StudentCompareByHeight : IComparer, IComparer<Student>
    {

        static StudentCompareHelper _studentCompareHelper;

        static StudentCompareByHeight()
        {
            _studentCompareHelper = new StudentCompareHelper();
        }

        /// <summary>
        /// 比较两个对象大小
        /// </summary>
        /// <param name="x">比较的第一个对象</param>
        /// <param name="y">比较的第二个对象</param>
        /// <returns>x is greater then y return 1;  x is less then y return  -1; ortherwise 0</returns>
        public int Compare(object x, object y)
        {
            return _studentCompareHelper.Compare(x, y, StudentCompareType.CompareByHeightAsc);
        }



        public int Compare(Student x, Student y)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 学生比较帮助类
    /// </summary>
    class StudentCompareHelper
    {
        public int Compare(object x, object y, StudentCompareType argCompareType)
        {
            if (x == y) return 0;     //同一对象 相等

            if (y == null) return 1;

            if (x == null) return -1;

            if (!(x is Student)) throw new ArgumentException("Param Must Be Student");  //比较参数类型错误异常提示
            Student stu1 = (Student)x;


            if (!(y is Student)) throw new ArgumentException("Param Must Be Student");
            Student stu2 = (Student)y;


            switch (argCompareType)
            {
                case StudentCompareType.CompareByHeightAsc:
                    return CompareByHeightAsc(stu1, stu2);

                case StudentCompareType.CompareByNameDesc:
                    return CompareByNameDesc(stu1, stu2);

                case StudentCompareType.CompareByNameLengthAsc:
                    return CompareByNameLengthAsc(stu1, stu2);

                default:
                    throw new Exception("比较类型超出范围");
            }
        }

        /// <summary>
        /// 根据升高升序比较
        /// </summary>
        /// <param name="stu1">比较的第一个对象</param>
        /// <param name="stu2">比较的第二个对象</param>
        /// <returns></returns>
        private static int CompareByHeightAsc(Student stu1, Student stu2)
        {
            if (stu1.Height > stu2.Height) return 1;
            if (stu1.Height < stu2.Height) return -1;
            return 0;
        }

        /// <summary>
        /// 根据名称字母降序排序
        /// </summary>
        /// <param name="stu1">比较的第一个对象</param>
        /// <param name="stu2">比较的第二个对象</param>
        /// <returns></returns>
        private static int CompareByNameDesc(Student stu1, Student stu2)
        {
            return -stu1.Name.CompareTo(stu2.Name);
        }

        /// <summary>
        /// 根据名称长度升序排序
        /// </summary>
        /// <param name="stu1">比较的第一个对象</param>
        /// <param name="stu2">比较的第二个对象</param>
        /// <returns></returns>
        private static int CompareByNameLengthAsc(Student stu1, Student stu2)
        {
            if (stu1.Name.Length > stu2.Name.Length) return 1;
            if (stu1.Name.Length < stu2.Name.Length) return -1;
            return 0;
        }
    }

    /// <summary>
    /// 学生排序枚举
    /// </summary>
    enum StudentCompareType
    {
        /// <summary>
        /// 按名称字母降序排序
        /// </summary>
        CompareByNameDesc,

        /// <summary>
        /// 按名称长度升序
        /// </summary>
        CompareByNameLengthAsc,


        /// <summary>
        /// 按身高升序
        /// </summary>
        CompareByHeightAsc,
    }


    #endregion

    #region 练习2   用List<T>管理元素

    /*========以下使用泛型List<T>做。                  
     * 创建一个只能添加整数的集合
     * 创建一个只能添加字符串类型的集合
     * 创建一个只能添加Person类型的集合
     * 分别调用Sort（）方法测试
     * 分别调用Sort（）的第三个重载     
     */

    /// <summary>
    /// 人的基类
    /// </summary>
    class Person : IComparable, IComparable<Person>
    {

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }


        public Person(string argName, int argAge)
        {
            Name = argName;
            Age = argAge;
        }

        /*
         * 当用数组来管理元素 排序不传IComparer参数时 调用此方法         
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is Person)) throw new ArgumentException("Argument Must Be Person");

            return this.CompareTo((Person)obj);
        }


        /*
         * 当用List<T>来管理元素 排序时不传IComparer<T>参数时 调用此方法         
        */
        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            if (Age > other.Age) return 1;

            if (Age < other.Age) return -1;

            return 0;
        }
    }

    /// <summary>
    /// 按年龄降序排序
    /// </summary>
    class PersonCompare : IComparer<Person>, IComparer
    {
        public int Compare(Person x, Person y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return -x.CompareTo(y);
        }

        public int Compare(object x, object y)
        {
            if (x == y) return 0;     //同一对象 相等

            if (y == null) return 1;

            if (x == null) return -1;

            if (!(x is Person)) throw new ArgumentException("Param Must Be Person");  //比较参数类型错误异常提示
            Person person1 = (Person)x;


            if (!(y is Person)) throw new ArgumentException("Param Must Be Person");
            Person person2 = (Person)y;

            return -person1.CompareTo(person2);
        }
    }

    #endregion

    #endregion

    #region Test

    ///// <summary>
    ///// 这里子类仍然实现接口  测试类型转换区别
    ///// </summary>
    //class Chinese : Person,IComparable,IComparable<Person>
    //{
    //    public Chinese(string argName,int argAge):base(argName,argAge)
    //    {

    //    }
    //}

    //interface IA
    //{
    //    void M1();
    //}

    //interface IB:IA
    //{
    //    void M2();
    //}


    //class A : IB, IA
    //{

    //    public void M2()
    //    {
    //        Console.WriteLine("实现了IB接口");
    //    }

    //    public void M1()
    //    {
    //        Console.WriteLine("实现了IA接口");
    //    }
    //}

    #endregion


}
