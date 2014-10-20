using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22222
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string argContent,Action<string> argAction)
            : this()
        {
            label1.Text = argContent;
            InformClose = argAction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(InformClose==null)return;
            InformClose(textBox1.Text.Trim());
            Close();
        }
    }
}
