using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace 文件操作
{
    class Program
    {
        static void Main(string[] args)
        {

            string a = "hello,您好！";

            //byte[] bytes=System.Text.Encoding.

            #region 1文件创建,删除，拷贝，移动，是否存在操作

            //1.创建一个文件 一系列的重载方法其实参数就是FileStream构造时候需要的参数
            //FileStream fsStream= File.Create(@"e:\hello.txt",1024*1024*5); //内部其实通过new FileStream 指定FileMode为Create来创建一个新文件      
            //Console.WriteLine(fsStream.Length);    
            //Console.WriteLine("ok");
            //Console.Read();

            //2.判断一个文件是否存在
            //bool b = File.Exists(@"e:\hello.txt");
            //Console.WriteLine(b);
            //Console.Read();

            //3.拷贝一个文件
            //File.Copy(@"e:\hello.txt", @"d:\hello.txt");
            //Console.WriteLine("ok");
            //Console.Read();

            //4.删除一个文件
            //文件的删除，即便文件不存在也不会报异常
            //File.Delete(@"d:\hello.txt");
            //Console.WriteLine("ok");
            //Console.Read();


            //5.移动一个文件           
            //File.Move(@"e:\hello.txt", @"d:\hello.txt");
            //Console.WriteLine("ok");
            //Console.Read();

            /*
             * 1Open()返回一个fileStream进行操作 OpenFile,OpenRead等都是对fileStream的简化封装操作
             * 2ReadAllBytes,2ReadAlllines,3ReadAllText 内部通过StreamReader完成
             * 3WriteAllBytes,2WriteAlllines,3WriteAllText StreamWriter
             */

            #endregion

            #region FileStream的操作 读取，写入


            string txt = "中国历史悠久，地大物博,四大文明古国，快点快点快点快点快点快点快点快点快点快点快点快点快点看看";
           
            byte[] buffer = System.Text.Encoding.Default.GetBytes(txt);

            #region 版本1： 非Using手动释放文件资源

            FileStream fs=null;

            try
            {
                //1创建一个文件流
                fs = new FileStream(@"c:\中国.txt", FileMode.OpenOrCreate, FileAccess.Write);

                //2读文件或者写文件
                fs.Write(buffer, 0, buffer.Length);

            }
            finally
            {
                ////3关闭文件流

                //fs.Flush();//清空缓冲区

                //fs.Close();//关闭文件流

                //四、释放相关资源 内部会调用//3中的两个方法
                if (fs!=null)
                {
                    fs.Dispose();
                }              
            }

            #endregion

            #region 版本2: Using使用 (1要求对象实现了IDispose接口 内部编译成try{}finally{}代码)

              //4采用Using释放资源
            using(FileStream fs1=new FileStream(@"c:\中国.txt",FileMode.OpenOrCreate,FileAccess.Write))
            {
                 fs1.Write(buffer,0,buffer.Length);                		 
            }

            #endregion                

            #region 案列：大文件流拷贝电影

            string sourcePath = @"F:\movie\异型.rmvb";

            string targePath = @"E:\异型.rmvb";       

            using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                //1创建缓冲区存储读取的字节
                byte[] buffers = new byte[1024 * 1024 * 10];

                using (FileStream fsWirte = new FileStream(targePath, FileMode.Create, FileAccess.Write))
                {
                    while (fsWirte.Length< fsRead.Length)
                    {
                        int byteCount = fsRead.Read(buffer, 0, buffers.Length);                     

                        fsWirte.Write(buffers, 0, byteCount);

                        Console.Clear();
                        Console.WriteLine("已复制{0}%", (fsWirte.Position * 1.0) / fsRead.Length * 100);
                    }
                }
            }



            #endregion


            #endregion

            #region 大文本文件文件流操作(StreamReader,StreamWriter内部封装了只读只写的FileStream进行文件操作) 

            using (StreamReader reader = new StreamReader("工资文件.txt", Encoding.Default))
            {                
                using (StreamWriter writer = new StreamWriter("输出工资文件.txt"))
                {                 
                    while (!reader.EndOfStream)
                    {
                        string parts = reader.ReadLine();

                        string[] contents = parts.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                        int salary = Convert.ToInt32(contents[1]) * 2;

                        contents[1] = salary.ToString();

                        writer.WriteLine(string.Join("|", contents));
                    }
                }
            }

            #endregion
           
            Console.ReadKey();
        }
    }
}


//打开解决方案: Ctrl+W+S
