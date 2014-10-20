using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 订阅者管理者：负责管理订阅者
    /// </summary>
    public class ObserverManager
    {
        List<IUpdateText> _observers = new List<IUpdateText>();

        /// <summary>
        /// 添加订阅者
        /// </summary>
        /// <param name="observer"></param>
        public void AttachObserver(IUpdateText observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// 移除订阅者
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IUpdateText observer)
        {
            if (!_observers.Contains(observer)) return;
            _observers.Remove(observer);
        }

        /// <summary>
        /// 分发订阅内容
        /// </summary>
        /// <param name="msg">消息内容</param>
        public void Dispatch(string msg)
        {
            foreach (var item in _observers)
            {
                item.SetText(msg);
            }
        }
    }
}
