using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Translate
{
    /// <summary>
    /// 字典的查询界面
    /// </summary>
    public partial class FormTranslator: Form
    {
        /// <summary>
        /// 翻译器
        /// </summary>
        private Translator _translator;


        public FormTranslator()
        {
            InitializeComponent();
            Load += FormDic_Load;
            cbbTranslateOption.SelectedIndexChanged += cbbTranslateOption_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                rTxtResult.Text = _translator.Translate(txtInput.Text.Trim());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        void cbbTranslateOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _translator = TranslateFactory.GetTranslator((TranslatorEnum)cbbTranslateOption.SelectedIndex);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }

        void FormDic_Load(object sender, EventArgs e)
        {
            try
            {
                cbbTranslateOption.SelectedIndex = 0;
                _translator = TranslateFactory.GetTranslator((TranslatorEnum)cbbTranslateOption.SelectedIndex);
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("{0},程序将推出",err.Message));
               
                Application.Exit(new CancelEventArgs(true));
            }
        }
    }
}
