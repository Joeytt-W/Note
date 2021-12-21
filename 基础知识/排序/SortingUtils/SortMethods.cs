using System;
using System.Collections;

namespace SortingUtils
{
    /// <summary>
    /// 排序（默认从小到大）
    /// </summary>
    public static class SortMethods
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="reverse">是否倒序</param>
        /// <returns></returns>
        public static T[] BubbleSorting<T>(this T[] arr, bool reverse = false) where T:IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[i].CompareTo(arr[j]) > 0)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            if (reverse)
                 Array.Reverse(arr);

            return arr;
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="reverse">是否倒序</param>
        /// <returns></returns>
        public static T[] SelectSorting<T>(this T[] arr, bool reverse = false) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                T temp = arr[i];
                int index = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (temp.CompareTo(arr[j]) > 0)
                    {
                        temp = arr[j];
                        index = j;
                    }
                }
                arr[index] = arr[i];
                arr[i] = temp;
            }

            if (reverse)
                Array.Reverse(arr);

            return arr;
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="reverse">是否倒序</param>
        /// <returns></returns>
        public static T[] ShellSorting<T>(this T[] arr, bool reverse = false) where T : IComparable
        {
            int gap = arr.Length / 2;
            while (gap >= 1)
            {
                //把距离为gap的元素编为一组
                for(int i = gap; i < arr.Length; i++)
                {
                    int j = 0;
                    T temp = arr[i];
                    //对距离为gap的元素进行比较
                    for (j = i - gap; j >= 0 && temp.CompareTo(arr[j]) < 0; j = j - gap)
                    {
                        arr[j + gap] = arr[j];
                    }
                    arr[j + gap] = temp;
                }
                gap = gap / 2;
            }

            if (reverse)
                Array.Reverse(arr);

            return arr;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="reverse">是否倒序</param>
        /// <returns></returns>
        public static T[] InsertSorting<T>(this T[] arr, bool reverse = false) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T temp = arr[i];
                int j;
                for (j = i - 1; j >= 0; j--)
                {
                    if (temp.CompareTo(arr[j]) > 0)
                    {
                        break;
                    }
                    arr[j + 1] = arr[j];
                }
                arr[j + 1] = temp;
            }

            if (reverse)
                Array.Reverse(arr);

            return arr;
        }
    }

}
