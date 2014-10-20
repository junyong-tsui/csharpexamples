using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodePadPlugInterface
{
    /// <summary>
    /// NotePad的格式化器接口
    /// </summary>
    public interface IFormmater
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        string PlugName{ get; }

        /// <summary>
        /// 格式化NotePad的内容
        /// </summary>
        /// <param name="richTextBox"></param>
        void Format(System.Windows.Forms.RichTextBox richTextBox);
    }
}
