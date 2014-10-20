using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        //Main:程序入口 CLR启动的时候会创建一个主线程(俗称UI线程) 是一个前台线程
        static void Main(string[] args)
        {
            //创建线程并绑定任务
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("hello world the fuzhuThread id is {0}",Thread.CurrentThread.ManagedThreadId);
                }
            });

            //重：一个进程退出的标志：所有的前台线程都已结束。后台线程不会阻塞进程的退出,所有前台线程结束后，所有的后台线程自动退出
            //01线程默认是前台线程IsBackground=false 一般情况下应该把线程设置为后台线程
            thread.IsBackground = true;
            

            //重：
            //02设置线程优先级后优先级真的有设的那么高吗？
            //建议Os将此线程的优先级设置的高些，但是实际上由Os决定
            thread.Priority = ThreadPriority.Highest;

            //重：
            //03启动线程后是立即执行吗？
            //告诉os当前线程已准备好去执行了，实际上什么时候执行由os决定
            thread.Start();

            //thread线程执行完成,完成后主线程再执行
            thread.Join(1000);//等待  

            //thread.Abort();//不得已才使用，直接终结线程，线程的方法体执行完后设置thread=null会自动释放

            //主线程任务
            while (true)
            {
                Console.WriteLine("from 主线程--{0}--",Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }           
        }
    }
}
