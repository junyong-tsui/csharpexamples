using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Treeview显示XMl
{
    /// <summary>
    /// 订单树
    /// </summary>
    public class TreeViewOrder : TreeView
    {
        /// <summary>
        /// 根据xml文件路径加载Xml树
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void Load(string xmlFilePath)
        {
            var xml = XDocument.Load(xmlFilePath);
            if (xml.Root == null) return;
            var rootNode = Nodes.Add(xml.Root.HasAttributes ? xml.Root.Name + ":" + xml.Root.FirstAttribute.Value : xml.Root.Name.ToString());
            rootNode.Tag = xml.Root;
            Load(xml.Root.Elements(), rootNode);
        }

        private static void Load(IEnumerable<XElement> elements, TreeNode argNode)
        {
            foreach (XElement xElement in elements)
            {
                //var subNode = new TreeNode
                //{
                //    Tag = xElement,
                //    Text =
                //        xElement.HasElements ?
                //        xElement.HasAttributes ?
                //        xElement.Name + ":" + xElement.FirstAttribute.Value :
                //        xElement.Name.ToString()
                //        : xElement.Name + ":" + xElement.Value 
                //};

                //argNode.Nodes.Add(subNode);
                //if (xElement.HasElements)
                //{
                //    Load(xElement.Elements(), subNode);
                //}

                var subNode = new TreeNode()
                {
                    Tag = xElement,
                    Text = xElement.HasAttributes ?
                    xElement.Name + ":" + xElement.FirstAttribute.Value : xElement.Name.ToString(),
                };           

                argNode.Nodes.Add(subNode);

                if (xElement.HasElements)
                {
                    Load(xElement.Elements(), subNode);
                }
                else
                {
                    subNode.Nodes.Add(xElement.Value);  
                }

            }
        }
    }

}
