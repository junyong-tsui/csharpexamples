using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using MineXmlSerializer;

namespace XML
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Person p = new Person()
            //{
            //    Name = "张三",
            //    Age = 10,
            //    Email = "sxdxgzr@126.com",
            //    HomeAddress = new Address()
            //    {
            //        Country = "China",
            //        Province = "无",
            //        City = "Beijing",
            //    },

            //    Arr = new List<int>() { 1, 2, 3, 4 },

            //    Arr1 = new int[] { 2, 3, 4, 5 }

            //};

            //Console.WriteLine("序列化前: 姓名:{0} 年龄:{1} 邮箱:{2}", p.Name, p.Age, p.Email);

            //#region 序列化Person对象

            //MyXmlSerializer serializer = new MyXmlSerializer();

            //serializer.Serialize(p);

            //#endregion

            //#region 反序列化Person对象

            //using (XmlTextReader reader = new XmlTextReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Person.xml")))
            //{
            //    p = (Person)serializer.DSerialize(reader, typeof(Person));
            //}

            //Console.WriteLine("序列化后: 姓名:{0} 年龄:{1} 邮箱:{2} ", p.Name, p.Age, p.Email);

            //#endregion

            //#region 反射访问泛型集合

            //Type type = typeof(Person);

            //PropertyInfo adressPropertyInfo = type.GetProperty("Arr");


            //var obj = adressPropertyInfo.GetValue(p) as IEnumerable;

            //if (obj!=null)
            //{
            //    foreach (var item in obj)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //}

            //#endregion    


            #region  1测试可变参数类型创建XMl

            XDocument xDocument = new XDocument
            (
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement
                ("Order", 
                    new XElement("CustomerName", "杨中科"),
                    new XElement("OrderNumber", "BJ200888"),
                    new XElement
                    ("Items",
                        new XElement("OrderItem",new XAttribute("Name", "电脑"),new XAttribute("Count", "30")),
                        new XElement("OrderItem",new XAttribute("Name", "电视"),new XAttribute("Count", "2")),
                        new XElement("OrderItem",new XAttribute("Name", "水杯"),new XAttribute("Count", "20"))
                    )
                )
            );

            xDocument.Save("订单.xml");

            #endregion 

            #region 2list集合创建Xml

            var list = new List<Person>() { 
            new Person(){ Name="刘尚鑫", Age=20, Email="lsx@yahoo.com"},
            new Person(){ Name="gwm", Age=21, Email="gwm@yahoo.com"},
            new Person(){ Name="pll", Age=19, Email="pll@yahoo.com"},
            new Person(){ Name="李晶晶", Age=20, Email="ljj@yahoo.com"}
            };


            XDocument xDocument1=new XDocument(new XDeclaration("1.0","utf-8","yes"));
         
            var root = new XElement("Class");
        
            xDocument1.Add(root);

            foreach (Person person in list)
            {
                var personElement=new XElement("Person");
              
                personElement.SetElementValue("Name",person.Name);
                personElement.SetElementValue("Age", person.Age);
                personElement.SetElementValue("Email", person.Email);   
                root.Add(personElement);       
            }    
   
            xDocument1.Save("hello.xml");     

            #endregion       

            #region 3读取订单Xml

            XDocument orderXDocument = XDocument.Load("订单.xml");

            if (orderXDocument.Root != null)
            {
                Console.WriteLine("订单人:" + orderXDocument.Root.Element("CustomerName").Value);

                Console.WriteLine("订单编号:" + orderXDocument.Root.Element("OrderNumber").Value);

                Console.WriteLine("订单明细:");

                foreach (XElement element in orderXDocument.Root.Descendants("Items").Descendants())
                {
                    Console.WriteLine("商品:{0} 价格{1} ", element.Attribute("Name").Value,
                        element.Attribute("Count").Value);
                }
            }

            #endregion  

            #region 4读取ytbank.xml文件

            XDocument xDocument5 = XDocument.Load("ytbank.xml");

            foreach (XElement msg in xDocument5.Root.Descendants("MSG"))
            {
                foreach (XElement info in msg.Elements())
                {
                    Console.WriteLine(info.Name+":"+info.FirstAttribute.Value);
                }

                Console.WriteLine("===============================");
            }
            
            #endregion     

            Console.ReadKey();
        }

        public class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }

            private bool sex;

            public bool Sex
            {
                get { return sex; }
            }

            public string Email { get; set; }

            public Address HomeAddress { get; set; }

            public List<int> Arr { get; set; }

            public int[] Arr1 { get; set; }

        }

        public class Address
        {
            public string Country { get; set; }

            public string Province { get; set; }

            public string City { get; set; }

        }
    }
}
