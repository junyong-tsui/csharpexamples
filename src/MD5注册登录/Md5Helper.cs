using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MD5注册登录
{
    /// <summary>
    /// md5帮助类
    /// </summary>
    public static class Md5Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string GetMd5FromString(string srcString)
        {

            byte[] src = Encoding.Default.GetBytes(srcString);
            using (var md5 = MD5.Create())
            {
                byte[] tar = md5.ComputeHash(src);
                return GetEncrptString(tar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetMd5FromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var fs = File.OpenRead(fileName))
                {
                    byte[] trc = md5.ComputeHash(fs);
                    return GetEncrptString(trc);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private static string GetEncrptString(byte[] target)
        {
            var sb = new StringBuilder();
            foreach (var item in target)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
