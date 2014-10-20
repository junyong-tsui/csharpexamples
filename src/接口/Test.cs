using System;

namespace OO封装继承多态.接口
{
    /*
     接口的实现者 显示、隐士实现的方法都会用virtual标记，意味着这些方法在子类类型
    * 对象的方法表里面也会存在，所谓的接口虚表。
     * 接口显示实现 主要是为了解决方法名称冲突问题。
     * 接口的实现者为抽象类时候接口成员可以抽象实现 用关键字 abstract override标记
    */

    #region 接口IFlyable继承

    /// <summary>
    /// 鸟
    /// </summary>
    internal abstract class Bird
    {
        public string Type { get; set; }
    }

    /// <summary>
    /// 麻雀
    /// </summary>
    internal class Sparrow : Bird, IFlyable
    {

        public void Fly()
        {
            Console.WriteLine("鸵鸟能飞");
        }
    }


    internal class A : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("鸵鸟能飞");
        }
    }

    /// <summary>
    /// 鹦鹉
    /// </summary>
    internal class Parrot : Bird, IFlyable
    {

        public void Fly()
        {
            Console.WriteLine("鹦鹉能飞");
        }
    }


    /// <summary>
    /// 鸵鸟
    /// </summary>
    internal class Ostrich : Bird
    {

    }


    /// <summary>
    /// 企鹅
    /// </summary>
    internal class Penguin : Bird
    {

    }


    internal interface IFlyable
    {
        void Fly();
    }

    #endregion

    #region 练习 接口成员组成 

    internal interface IMemberTest
    {
        void M1();

        string M3(string argMemberName);

        /// <summary>
        /// 自动属性在接口里面自动标识为未实现，而在类里面标识为自动属性
        /// </summary>
        string Named { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        event EventHandler M2;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string this[int index]
        { get; set; }
    }


    #endregion

    #region 教师，学生，人，教师学生能收作业

    /// <summary>
    /// 人
    /// </summary>
    public class People
    {
        //名称
        private string _firstName;

        //姓
        private string _lastName;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get { return _firstName + _lastName; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }


        /// <summary>
        /// 打招呼
        /// </summary>
        /// <param name="argSayHello">封装具体打招呼的方法</param>
        public void SayHello(Action argSayHello)
        {
            if (argSayHello != null)
            {
                argSayHello();
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="argFirstName">名称</param>
        /// <param name="argLastName">姓</param>
        /// <param name="argAge">年龄</param>
        public People(string argFirstName, string argLastName, int argAge)
        {
            _firstName = argFirstName;
            _lastName = argLastName;
            Age = argAge;
        }
    }

    /// <summary>
    /// 收作业接口(较小功能 且体现Can Do 这里应该定义成接口)
    /// </summary>
    public interface ICollectHomeWork
    {
        /// <summary>
        /// 收作业
        /// </summary>
        void CollectHomeWork();
    }

    /// <summary>
    /// 校长
    /// </summary>
    public class HeadMaster : People
    {
        /// <summary>
        /// 管理学校
        /// </summary>
        public void ManageSchcol()
        {
            Console.WriteLine("校长{0}管理学校", Name);
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="argFirstName">名称</param>
        /// <param name="argLastName">姓</param>
        /// <param name="argAge">年龄</param>
        public HeadMaster(string argFirstName, string argLastName, int argAge) :
            base(argFirstName, argLastName, argAge)
        {

        }
    }

    /// <summary>
    /// 教师
    /// </summary>
    public class Teacher : People, ICollectHomeWork
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="argFirstName">名称</param>
        /// <param name="argLastName">姓</param>
        /// <param name="argAge">年龄</param>
        public Teacher(string argFirstName, string argLastName, int argAge) :
            base(argFirstName, argLastName, argAge)
        {

        }

        /// <summary>
        /// 教学
        /// </summary>
        public void Teching()
        {
            Console.WriteLine("老师{0}认真教学", Name);
        }




        #region  ICollectHomeWork 实现

        /// <summary>
        /// 收作业 默认标记为private 也就是说显示实现只能通过接口来调用， 通过类型对象的接口虚表来调用。 显示与隐士实现的区别就在于方法的标记不同而已，但是实现都会标记为虚方法，也就是说子类类型对象的方法表里面会有这个内容
        /// </summary>
        void ICollectHomeWork.CollectHomeWork()
        {
            Console.WriteLine("老师{0}收作业", Name);
        }

        #endregion

    }

    /// <summary>
    /// 学生
    /// </summary>
    public class Student : People, ICollectHomeWork
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="argFirstName">名称</param>
        /// <param name="argLastName">姓</param>
        /// <param name="argAge">年龄</param>
        public Student(string argFirstName, string argLastName, int argAge) :
            base(argFirstName, argLastName, argAge)
        {

        }

        /// <summary>
        /// 学习
        /// </summary>
        public void Learning()
        {
            Console.WriteLine("学生{0}努力学习", Name);
        }


        #region  ICollectHomeWork 实现

        /// <summary>
        /// ICollectHomeWork 实现
        /// </summary>
        public void CollectHomeWork()
        {
            Console.WriteLine("学生{0}收作业", Name);
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal class ClassMaster : Student
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="argFirstName">名称</param>
        /// <param name="argLastName">姓</param>
        /// <param name="argAge">年龄</param>
        public ClassMaster(string argFirstName, string argLastName, int argAge) :
            base(argFirstName, argLastName, argAge)
        {

        }
    }

    #endregion
}

