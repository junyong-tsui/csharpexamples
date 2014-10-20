using System;
using System.Collections.Generic;

namespace Translate
{
    /// <summary>
    /// 翻译器的工厂类 返回翻译器字典
    /// </summary>
    public static class TranslateFactory
    {
        private static Dictionary<string, Translator> _translators;
    
        static TranslateFactory()
        {
            _translators=new Dictionary<string, Translator>();
        }


        /// <summary>
        /// 根据翻译类型获取翻译器  反射就会对修改封闭
        /// </summary>
        /// <param name="argTranslateType">翻译器类型</param>
        /// <returns></returns>
        public static Translator GetTranslator(TranslatorEnum argTranslateType)
        {
            try
            {
                //位于同一程序集 且类型规则确定 直接硬编码
                string typeName = "Translate." + argTranslateType + "Translator";

                if (_translators.ContainsKey(typeName)) return _translators[typeName];

                Translator translator = (Translator) System.Activator.CreateInstance(Type.GetType(typeName));

                _translators.Add(typeName,translator);

                return translator;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
      
    }
}
