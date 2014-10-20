using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region QueueUserWorkItem           
           
            //WaitCallback

            //线程池的线程本身都是 后台线程
            //线程池的线程优势:线程可以进行重用
            //启动一个线程:开辟一个内存空间,默认情况下持有1M的执行栈,有可能占有一部分寄存器
            //线程数比较多，cpu频繁在线程间切换，切换前会保存现场，切换回来会恢复现场，效率较低。
            //线程池的最大线程数：1024 默认1000个
            //什么时候使用线程池？什么时候使用创建线程？
                //1能使用线程池使用线程池，缺点工作项执行顺序不确定，线程由线程池控制
                //2需要手动控制线程的结束：则需要手动创建线程。


            ThreadPool.QueueUserWorkItem((s) => { Console.WriteLine(s); },"ssss");

            #endregion

            #region 异步委托 无回调函数

            //result.AsyncWaitHandle 基于信号量的机制暂不清楚，回头在弄清楚。

            Func<int, int, string> decFunc = (a, b) =>
            {
                Console.WriteLine("the task thread id is {0}",Thread.CurrentThread.ManagedThreadId);
                return (a + b).ToString();
            };

            IAsyncResult result = decFunc.BeginInvoke(3, 4, null, null);

            //EndInvoke 方法会阻塞当前的线程 直到异步委托指向完成之后，才继续往下执行
            string str = decFunc.EndInvoke(result);

            Console.WriteLine(str);


            #endregion

            #region 异步委托 有回调函数

            //AsyncCallback callback = (asynResult) => { Console.WriteLine("hello"); };

            decFunc.BeginInvoke(3, 4, MyAsynCallBack, result);

            //回调方法获取异步操作结果更为简单的做法
            //decFunc.BeginInvoke(3, 4, callback, decFunc); 

            #endregion

            Console.ReadKey();
        }

        //回调函数:是异步委托方法执行完成之后再回来调用回调函数 回调函数和异步委托的方法体是在一个线程里面执行
        static void MyAsynCallBack(IAsyncResult result)
        {
            //1拿到异步委托执行的结果
            AsyncResult subResult = (AsyncResult)result;           
            var del=(Func<int,int,string>)subResult.AsyncDelegate;
            string returnValue = del.EndInvoke(result);

            //2拿到给回调函数的参数 result.AsyncState持有传过来的参数
            Console.WriteLine(result.AsyncState);
            Console.WriteLine("the excute thread id is {0}",Thread.CurrentThread.ManagedThreadId);
        }
    }
}
