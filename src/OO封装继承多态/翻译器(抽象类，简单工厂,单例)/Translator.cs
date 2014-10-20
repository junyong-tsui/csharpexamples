using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Translate
{
 
    /// <summary>
    /// 翻译器的抽象基类 
    /// </summary>
    public abstract class Translator
    {
        /// <summary>
        /// 翻译器翻译时用的字典
        /// </summary>
        protected abstract Dictionary<string, string> Dictionary { get; }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="argWord">单词</param>
        /// <returns></returns>
        public virtual string Translate(string argWord)
        {
            string word= argWord.ToLower();
            return Dictionary.ContainsKey(word) ? Dictionary[word] : "字典中不存在该词";
        }
    }

    /// <summary>
    /// 英译汉翻译器
    /// </summary>
    public class EnglishToChineseTranslator : Translator
    {

        private static Dictionary<string, string> _englishToChineseDic;
      
        /// <summary>
        /// 字典
        /// </summary>
        protected override Dictionary<string, string> Dictionary
        {
            get
            {
                return _englishToChineseDic;
            }
        }

        static EnglishToChineseTranslator()
        {
            _englishToChineseDic = GetEnglishToChineseDictionary();
        }

        /// <summary>
        /// 返回英译汉的字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetEnglishToChineseDictionary()
        {
            if (_englishToChineseDic != null) return _englishToChineseDic;

            string[] contents = File.ReadAllLines("英汉词典TXT格式.txt", Encoding.Default);

            var dic = new Dictionary<string, string>();

            foreach (string content in contents)
            {
                string[] word = content.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (word.Length != 2) continue;
                if (dic.ContainsKey(word[0]))
                {
                    dic[word[0]] += Environment.NewLine + word[1];
                }
                else
                {
                    dic.Add(word[0], word[1]);
                }
            }

            _englishToChineseDic = dic;

            return _englishToChineseDic;
        }
    }

    /// <summary>
    /// 汉译英翻译器
    /// </summary>
    public class ChineseToEnglishTranslator : Translator
    {
        static Dictionary<string, string> _chineseToEnglishDic;
     
        /// <summary>
        /// 字典
        /// </summary>
        protected override Dictionary<string, string> Dictionary
        {
            get
            {
                return _chineseToEnglishDic;
            }
        }

        static ChineseToEnglishTranslator()
        {
            _chineseToEnglishDic = GetChineseToEnglishDictionary();
        }

        /// <summary>
        /// 返回汉译英的字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetChineseToEnglishDictionary()
        {
            throw new NotSupportedException("未实现");
        }
    }

    /// <summary>
    /// 汉译火星语翻译器
    /// </summary>
    public class ChineseToMarsTranslator : Translator
    {

        static Dictionary<string, string> _chineseToMarsDic;
       
        /// <summary>
        /// 字典
        /// </summary>
        protected override Dictionary<string, string> Dictionary
        {
            get
            {
                return _chineseToMarsDic;
            }
        }

        static ChineseToMarsTranslator()
        {
            _chineseToMarsDic = GetChineseToMarsDictionary();
        }

        /// <summary>
        /// 返回汉译火星语字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetChineseToMarsDictionary()
        {
            if (_chineseToMarsDic != null) return _chineseToMarsDic;

            string[] contents = File.ReadAllLines("火星文.txt", Encoding.Default);

            string content1 = File.ReadAllText("火星文.txt", Encoding.Default);

            var dic = new Dictionary<string, string>();

            foreach (string content in contents)
            {
                string[] word = content.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (word.Length != 2) continue;
                if (dic.ContainsKey(word[0]))
                {
                    dic[word[0]] += Environment.NewLine + word[1];
                }
                else
                {
                    dic.Add(word[0], word[1]);
                }
            }

            _chineseToMarsDic = dic;

            return _chineseToMarsDic;
        }
    }
}
