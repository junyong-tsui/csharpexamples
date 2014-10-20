using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NodePadPlugInterface;

namespace NodePadPlugImplement1
{
    public class ConvertToUpper:IFormmater
    {
        public string PlugName
        {
            get { return "转换大写"; }
        }

        public void Format(System.Windows.Forms.RichTextBox richTextBox)
        {
          richTextBox.Text= richTextBox.Text.ToUpper();
        }
    }
}
