using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReadUploadDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //1读取打开文件路径
            OpenFileDialog ofd=new OpenFileDialog();
            if (ofd.ShowDialog()!=DialogResult.OK) return;

            using (FileStream fs=new FileStream(ofd.FileName,FileMode.Open))
            {
                using (StreamReader reader=new StreamReader(fs,Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        richTextBoxContent.AppendText(line+Environment.NewLine);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd=new SaveFileDialog())
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                using (var fsWrite=File.OpenWrite(sfd.FileName))
                {
                    byte[] content = Encoding.Default.GetBytes(richTextBoxContent.Text);
                    fsWrite.Write(content, 0, content.Length);
                }
            }
        }
    }
}
