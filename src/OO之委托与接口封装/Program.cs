using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO之委托与接口封装
{

     //多态值委托与接口的区别:
     /*
        接口是契约，也是能力，定义接口也要符合单一职责(引起变化的原因只有一个),一般作为中间组件解耦,意味着不同的子类对其
      * 会有不同的实现方式，多态。子类可以跨家族,抽象级别较抽线类高,抽象类要求子类同一加载。
      * 
      * 而委托的多态在于 ：委托能封装方法签名及返回值一致的方法,而不管对象具体是什么类型,此级别的封装是不能作为组件级别来
      * 封装的，只是对某个功能的变化点进行封装，让调用该功能的客户能将代码注入到该功能中,从而实现的一种多态。      
      */


     //整个Linq系统中的泛型委托就是较为经典的列子，用户调用时候将代码注入,完成相应的功能。

    class Program
    {
       
        static void Main(string[] args)
        {
         
        }
    }

}
