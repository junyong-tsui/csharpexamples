using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace 序列化
{
    /*
     序列化就是将对象的状态信息以某种编码存贮至其他媒介，这样 便于存储和传输,常用序列化有:二进制序列化,xml序列化,
     * javascriptSerializationS
     * 就是将对象的信息以另一种方式来表达，在需要的时候反序列化用,体现了值级别的复用。
     */
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 二进制序列化

            /*二进制序列化又叫做深拷贝,会拷贝对象的所有状态信息(字段+属性)包含类型定义的信息,序列化成一个二进制文件。
             * 反序列化的时候会根据序列化文件内部利用反射还原对象的状态信息。这个反射不需要序列化对象提供默认的无参构造函数           
             */

            //Student person = new Student("张三", "sxdxgzr@126.com", 100, true);

            //BinaryFormatter fs = new BinaryFormatter();
         
            //using (FileStream fsWriter = new FileStream("hello.bin", FileMode.Create))
            //{
            //    fs.Serialize(fsWriter, person);
            //}

            //using (FileStream fsReader = new FileStream("hello.bin", FileMode.Open))
            //{
            //    var p = fs.Deserialize(fsReader) as Student;
            //}


            #endregion

            #region xml序列化

            //序列化的时候要求提供的类型必须有无参的构造函数，否则报错，也就是反射的时候创建对象的时候就是无参的构造函数
            //反序列化的内部其实就是利用反射技术创建指定类型的实例,再根据序列化的信息给实例赋值


            var type = typeof(Student);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));

            Student person = new Student("张三", "sxdxgzr@126.com", 100, true){Dic = new Dictionary<string, int>(){{"a",1}}};

            using (var writer = new StreamWriter("人员.xml"))
            {
                xmlSerializer.Serialize(writer, person);
            }

            Console.WriteLine("Persom的xml序列化成功");

            using (var reader = new StreamReader("人员.xml"))
            {
                person = xmlSerializer.Deserialize(reader) as Student;
            }

            Console.WriteLine("Person的xml反序列化成功");


            #endregion

            #region JavaScriptSerialization 序列化为js的通用josn数据格式

            //Student person = new Student("张三", "sxdxgzr@126.com", 100, true);

            //JavaScriptSerializer javaScriptSerializer=new JavaScriptSerializer();

            //string result= javaScriptSerializer.Serialize(person);

            //var  obj= javaScriptSerializer.Deserialize(result, typeof (Student)) as Student;

            //Console.WriteLine(obj.Name);

            #endregion

            Console.ReadKey(); 
        }
    }


    /// <summary>
    ///序列化对象的时候会查找其对象图(判断对象引用的对象是否可以序列化 否则当前对象不能序列化) vs序列化的机制，、
    /// 暂不清楚这样做的好处
    /// </summary>
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        private bool _sex;

        public Dictionary<string,int> Dic
        {
            get; set;
        } 

        public Student()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public Student(string argName,string argEmail,int argAge,bool argSex)
        {
            Name = argName;
            Email = argEmail;
            Age = argAge;
            _sex = argSex;
        }
    }
}
