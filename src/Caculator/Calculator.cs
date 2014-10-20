using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCaculator;

namespace ConcreteCaculator
{
    /// <summary>
    /// 加法计算类
    /// </summary>
    public class Add : Caculator
    {
        #region Construcor

        public Add(double argNum1, double argNum2)
            : base(argNum1, argNum2)
        {

        }


        #endregion

        public override double Caculate()
        {
            return Num1 + Num2;
        }
    }

    /// <summary>
    /// 减法计算类
    /// </summary>
    public class Subtruct : Caculator
    {
        #region Construcor

        public Subtruct(double argNum1, double argNum2)
            : base(argNum1, argNum2)
        {

        }

        #endregion

        public override double Caculate()
        {
            return Num1 - Num2;
        }
    }

    /// <summary>
    /// 减法计算类
    /// </summary>
    public class Multiple : Caculator
    {
        #region Construcor

        public Multiple(double argNum1, double argNum2)
            : base(argNum1, argNum2)
        {

        }

        #endregion

        public override double Caculate()
        {
            return Num1 * Num2;
        }
    }

    /// <summary>
    /// 除法计算类
    /// </summary>
    public class Divide : Caculator
    {
        #region Construcor

        public Divide(double argNum1, double argNum2)
            : base(argNum1, argNum2)
        {

        }

        #endregion

        public override double Caculate()
        {
            if ((int)Math.Abs(Num2 - 1e-7) == 0) throw new Exception("除数不能为0");


            return Math.Round(Num1 / Num2, 2);
        }
    }
}
