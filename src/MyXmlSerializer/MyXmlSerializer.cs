using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace MineXmlSerializer
{
    /// <summary>
    /// Person的序列化器  模拟系统的序列化功能
    /// </summary>
    public class MyXmlSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">Person对象</param>
        public void Serialize(object obj)
        {
            //1创建xdocment
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

            //2构建代表对象的Xml
            Type type = obj.GetType();
            XElement objXElement = CreateXElement(type.Name, obj);
            if (objXElement != null)
            {
                xdocment.Add(objXElement);
            }

            //3将_xdocment存至磁盘中
            xdocment.Save("Person.xml");
        }

        /// <summary>
        /// 根据对象创建XElement
        /// </summary>
        /// <param name="elementName">元素名</param>
        /// <param name="obj">元素值</param>
        /// <returns></returns>
        private static XElement CreateXElement(string elementName, object obj)
        {
            //1
            if (obj == null) return null;     

            XElement element = new XElement(elementName);
            Type type = obj.GetType();

            //2委托类型不序列化
            if (type.IsSubclassOf(typeof(Delegate)))
            {
                return null;
            }

            //3基元类型、string类型、DateTime类型 存其值
            if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime))
            {
                element.Value = obj.ToString();

                return element;
            }


            //4可迭代类型处理   元素标签为元素类型的名称 值为元素的值
            var objEnumbale = obj as IList;

            if (objEnumbale != null)
            {
                foreach (var item in objEnumbale)
                {
                    var itemType = item.GetType();

                    element.Add(new XElement(itemType.Name, item.ToString()));

                }

                return element;
            }

            //5非迭代的引用类型(除委托，string类型外)
            //1构建obj字段的xml
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo field in fieldInfos)
            {
                var fieldXelement = CreateXElement(field.Name, field.GetValue(obj));
                if (fieldXelement != null)
                {
                    element.Add(fieldXelement);
                }
            }

            //2构建obj属性的xml
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var propertyXelement = CreateXElement(propertyInfo.Name, propertyInfo.GetValue(obj));

                if (propertyXelement != null)
                {
                    element.Add(propertyXelement);
                }
            }

            return element;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="reader">读取器</param>
        /// <param name="type">反序列化的类型</param>
        /// <returns></returns>
        public object DSerialize(XmlReader reader, Type type)
        {
            //1加载序列化的XML文件
            XDocument xDocumen = XDocument.Load(reader);
            if (xDocumen.Root == null) return null;

            //2反射创建对象并返回
            return CreateObj(xDocumen.Root.Elements(), type);
        }

        /// <summary>
        /// 反序列化创建对象
        /// </summary>
        /// <param name="elements">xml元素集合</param>
        /// <param name="type">对象的类型</param>
        private static object CreateObj(IEnumerable<XElement> elements, Type type)
        {
            //1不包含元素序列返回null
            if (elements == null || !elements.Any()) return null;
          
            //2创建对象实例
            object obj = type.IsArray ?
                Array.CreateInstance(type.GetElementType(),elements.Count()):
                System.Activator.CreateInstance(type);
           

            //3集合类型处理 只支持实现了IList<T>接口的集合类型
            IList objEnumerable = obj as IList;

            if (objEnumerable!=null)
            {
                if (type.IsArray)
                {
                    Type elementType = type.GetElementType();

                    if (elementType != null)
                    {
                        int i = 0;
                        foreach (XElement element in elements)
                        {
                            objEnumerable[i++] = (Convert.ChangeType(element.Value, elementType));
                        }

                        return objEnumerable;
                    }
                }

                if (type.IsGenericType)
                {
                    Type[] geneticParamTypes = type.GetGenericArguments();

                    if (geneticParamTypes.Length==1)
                    {
                        foreach (XElement element in elements)
                        {
                            objEnumerable.Add(Convert.ChangeType(element.Value, geneticParamTypes[0]));
                        }

                        return objEnumerable;
                    }
                }
            }


            #region 4非集合类型的处理

             //01设置对象公开可写属性的值
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!propertyInfo.CanWrite) continue;

                XElement element = (elements.Where(c => c.Name.ToString() == propertyInfo.Name)).FirstOrDefault();

                if (element == null) continue;

                propertyInfo.SetValue(obj,
                    !element.HasElements
                        ? Convert.ChangeType(element.Value, propertyInfo.PropertyType)
                        : CreateObj(element.Elements(), propertyInfo.PropertyType));
            }

            //02设置对象公开字段的值
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                XElement element = (elements.Where(c => c.Name.ToString() == fieldInfo.Name)).FirstOrDefault();

                if (element == null) continue;

                fieldInfo.SetValue(obj,
                    !element.HasElements
                        ? Convert.ChangeType(element.Value, fieldInfo.FieldType)
                        : CreateObj(element.Elements(), fieldInfo.FieldType));
            }

            return obj;

	        #endregion
        }
    }
}
