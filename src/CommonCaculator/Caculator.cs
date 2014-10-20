using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCaculator
{
    /// <summary>
    /// 计算抽象的基类
    /// </summary>
    public abstract class Caculator
    {

        #region Properties

        /// <summary>
        /// 操作数1
        /// </summary>
        public double Num1 { get; set; }

        /// <summary>
        /// 操作数2
        /// </summary>
        public double Num2 { get; set; }

        #endregion


        #region Constructor

        protected Caculator(double argNum1, double argNum2)
        {
            Num1 = argNum1;
            Num2 = argNum2;
        }

        #endregion


        /// <summary>
        /// 计算  
        /// </summary>
        /// <returns></returns>
        public abstract double Caculate();
    }
}
