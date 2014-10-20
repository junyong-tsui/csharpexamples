using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NodePadPlugInterface;

namespace NodePad
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// 插件的dll路径
        /// </summary>
        readonly string _pluginDllPath=Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugin");


        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            //加载插件
            foreach (string file in Directory.GetFiles(_pluginDllPath,"*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(file);

                foreach (Type type in assembly.GetTypes())
                {
                    Type editor = typeof (IFormmater);

                    if(editor.IsAssignableFrom(type)&&!type.IsAbstract)
                    {
                        IFormmater formmater = (IFormmater)System.Activator.CreateInstance(type);

                        var toolItem= tsbFormat.DropDownItems.Add(formmater.PlugName);


                        toolItem.Click += toolItem_Click;

                        toolItem.Tag = formmater;
                    }
                }

            }
        }

        void toolItem_Click(object sender, EventArgs e)
        {
            var toolItem = sender as ToolStripMenuItem;
            if (toolItem!=null&&toolItem.Tag!=null)
            {
                IFormmater formmater = (IFormmater) toolItem.Tag;
                formmater.Format(rtbContent);
            }
        }
    }
}
