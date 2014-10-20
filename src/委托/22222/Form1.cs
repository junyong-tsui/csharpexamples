using System;
using System.Windows.Forms;

namespace _22222
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form2(textBox1.Text.Trim(),UpdateTexBox);
            frm.Show();
        }

        private void UpdateTexBox(string argContent)
        {
            textBox1.Text = argContent;
        }
    }
}
