using System;

namespace OO封装继承多态
{
    /// <summary>
    /// 代表抽象的移动设备，不用接口是由于 1移动设备体系体现is -a关系，2功能模块算是比较大
    /// </summary>
    internal abstract class MobileDevice
    {
        /// <summary>
        /// 读数据
        /// </summary>
        public abstract object Read();

        /// <summary>
        /// 写数据
        /// </summary>
        public abstract void Write(object argData);

    }

    /// <summary>
    /// U盘设备
    /// </summary>
    internal class UDisk : MobileDevice
    {

        public override object Read()
        {
            //读取数据

            Console.WriteLine("读数据");
            return new object();
        }

        public override void Write(object argData)
        {
            //写数据

            Console.WriteLine("写数据");
            //.......
        }
    }

    /// <summary>
    /// Mp3设备
    /// </summary>
    internal class Mp3 : MobileDevice
    {
        public override object Read()
        {
            //读取数据

            Console.WriteLine("读数据");
            return new object();
        }

        public override void Write(object argData)
        {
            //写数据

            Console.WriteLine("写数据");
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        public void PlayMusic()
        {
            Console.WriteLine("Mp3播放歌曲");
        }
    }

    /// <summary>
    /// 移动硬盘
    /// </summary>
    internal class MobileHardDisk : MobileDevice
    {

        public override object Read()
        {
            //读取数据
            //.....
            Console.WriteLine("读数据");

            return new object();
        }

        public override void Write(object argData)
        {
            //写数据
            Console.WriteLine("写数据");
        }
    }

    /// <summary>
    /// 计算机
    /// </summary>
    internal class Computer
    {
        private MobileDevice _mobileDevice;

        /// <summary>
        /// 移动设备
        /// </summary>
        public MobileDevice MobileDevice
        {
            get { return _mobileDevice; }

            set
            {
                if (_mobileDevice == value) return;
                _mobileDevice = value;
                PrepareMobleDevice();
            }
        }

        /// <summary>
        /// 为移动设备使用做必要的准备工会
        /// </summary>
        /// <param name="argMobileDevice"></param>
        private void PrepareMobleDevice()
        {
            //为移动设备做必要的初始化工作
        }

        /// <summary>
        /// 读数据 ：移动设备读取的数据返回给电脑
        /// </summary>
        /// <returns>object 返回读取的数据</returns>
        public object ReadData()
        {
            if (MobileDevice != null)
                return MobileDevice.Read();

            return null;
        }

        /// <summary>
        /// 写数据 ：电脑上数据写回到移动设备
        /// </summary>
        /// <param name="argData">写入移动设备的数据</param>
        public void WriteData(object argData)
        {
            if (MobileDevice != null) MobileDevice.Write(argData);
        }
    }


    #region 抽象实现父类Test  用abstract override标记成员抽象实现 即交给子类实现

    //abstract class HelloDisk : MobileDevice
    //{
    //    public abstract override object Read();     //抽象方法可以抽象重写，表示子类无能力实现,交给子去实现

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="argData"></param>
    //    public virtual void Write(object argData)   //
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    #endregion
}
