using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncThreadDemo
{
    /*
        生产者消费者问题 简单模拟连接池
     * ----------分析---------------
     * -----问题原型：生产者生产连接对象，消费者连接对象。生产者生产的连接对象会放至连接池中，消费者会从连接池中去连接消费。
     * -----------01 生产者和消费者都会访问连接池，生产者会使连接池中的连接对象增加，消费者会使连接池中的对象减少，那么
     * -----当连接池里放满了连接对象后则生产者不能继续生产，消费者消费完了连接对象也不能继续消费。
     * -----------02 生产者和消费者都是在不同的线程中执行的，意味着生产者、消费者对连接池的访问不是独占访问。
     * -----------03 多线程执行特点可以推断：生产者和消费者可能会读脏数据，同时程序也可能会异常，。
     * -----------04 其实简单一分析生产者与生产者,消费者与消费者,生产者与消费者之间都是应该独占访问连接池对象的，否则它们
     * -----要么读脏数据，要么程序由于非法操作连接池对象而异常退出。
     * -----------05 lock机制，只要所有的生产者和消费者lock同一对象,那么就可以实现在同一时刻只有一个线程对连接池进行操作。
     * -----这样保证了它们正确的读取数据，程序按我们预期那样执行。
     */

    class Program
    {
        /// <summary>
        /// 连接对象池，其他的判断逻辑等等移除后其实就是一个数组而已
        /// </summary>
        static MyConnection[] connectionPool = new MyConnection[100];

        /// <summary>
        /// 可用连接对象的最大索引值
        /// </summary>
        static int index = -1;

        static void Main(string[] args)
        {
            //错误理解问题：给一个为null的变量赋值为null是可以的，这是因为只是将null加载指定的内存即可 
            //消费者消费的很快(较生产者而言)，某一时刻index=0的时候多个线程同时进入后执行了index--会造成index值不合法
            connectionPool[0] = null;

            #region 创建消费者
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        if (index >= 0)
                        {
                            connectionPool[index] = null;
                            Console.WriteLine("消费者消费了连接对象" + index);
                            index--;
                        }

                        Thread.Sleep(100);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }

            #endregion

            #region 创建生产者
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        if (index > 99) return;
                        connectionPool[++index] = new MyConnection();
                        Console.WriteLine("生产了一个连接对象 :" + index);
                        Thread.Sleep(1);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }

            #endregion

            Console.ReadKey();
        }
    }

    class MyConnection
    {
    }
}
