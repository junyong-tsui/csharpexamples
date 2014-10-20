using System;

namespace SortDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            //bubble sort
            BubbleSort(arr);
            Console.WriteLine(string.Join(",", arr));

            //insert sort
            Insert_Sort(arr);
            Console.WriteLine(string.Join(",", arr));

            Console.ReadKey();
        }


        #region 交换排序

        #region 冒泡排序

        //算法思路:
        //1从数组最后一个元素开始，比较相邻的元素，若后面元素比前面元素小则交换两个元素的位置。
        //2重复1 n-1趟，每趟会产生一个较小的元素，n-1趟后元素就会有序

        static void BubbleSort(params int[] arr)
        {
            //比较次数: arr.Length-1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //比较相邻的元素
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] >= arr[j - 1]) continue;

                    //后面元素小则交换元素的顺序
                    int tmp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = tmp;
                }
            }
        }

        #endregion

        #region 快速排序

        //快速排序使用分治法（Divide and conquer）策略来把一个串行（list）分为两个子串行（sub-lists）。
         //步骤为：
                  //从数列中挑出一个元素，称为 "基准"（pivot），
                  //重新排序数列，所有元素比基准值小的摆放在基准前面，所有元素比基准值大的摆在基准的后面（相同的数可以到任一边）。在这个分区退出之后，该基准就处于数列的中间位置。这个称为分区（partition）操作。
                  //递归地（recursive）把小于基准值元素的子数列和大于基准值元素的子数列排序。
                  //递归的最底部情形，是数列的大小是零或一，也就是永远都已经被排序好了。虽然一直递归下去，但是这个算法总会退出，因为在每次的迭代（iteration）中，它至少会把一个元素摆到它最后的位置去

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="numbers"></param>
        public static void QuickSort(int[] numbers)
        {
            Sort(numbers, 0, numbers.Length - 1);
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void QuickSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int middle = numbers[(left + right) / 2];
                int i = left - 1;
                int j = right + 1;
                while (true)
                {
                    while (numbers[++i] < middle) ;

                    while (numbers[--j] > middle) ;

                    if (i >= j)
                        break;

                    Swap(numbers, i, j);
                }

                QuickSort(numbers, left, i - 1);
                QuickSort(numbers, j + 1, right);
            }
        }

        private static void Swap(int[] numbers, int i, int j)
        {
            int number = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = number;
        }

        #endregion
        
        #endregion

        #region 选择排序

        #region 选择排序
        
        #endregion

        #endregion

        #region 插入排序

        #region 插入排序

        //工作原理是通过构建有序序列，对于未排序数据，在已排序序列中从后向前扫描，找到相应位置并插入

        //算法思路
        //1从第一个元素开始，该元素可以认为已经被排序
        //2取出下一个元素，在已经排序的元素序列中从后向前扫描
        //3如果该元素（已排序）大于新元素，将该元素移到下一位置
        //4重复步骤3，直到找到已排序的元素小于或者等于新元素的位置
        //5将新元素插入到该位置后
        //6重复步骤2~5


        //试用场景
        //1量级小于千，那么插入排序还是一个不错的选择。 
        //2插入排序在工业级库中也有着广泛的应用，在STL的sort算法和stdlib的qsort算法中，都将插入排序作为快速排序的补充，用于少量元素的排序（通常为8个或以下）

        private static void Insert_Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //1当前待排序的元素
                int currentElem = arr[i];

                //2 i前面的元素可以看成有序数组 默认情况下只有arr[0]的数组
                int j = i;

                //3 有序数组中大于currentElem的后移 停止循环时则找到了插入位置j
                while (j > 0 && arr[j - 1] > currentElem)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                //4currentElem
                arr[j] = currentElem;
            }
        }

        #endregion

        #region 希尔排序
        
        #endregion

        #region 二叉查找树排序
        
        #endregion

        #region 图书馆排序
        
        #endregion

        #region Patience排序
        
        #endregion

        #endregion
    }


}
