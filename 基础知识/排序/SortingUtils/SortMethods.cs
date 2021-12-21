using System;
using System.Collections;

namespace SortingUtils
{
    public static class SortMethods
    {
        /// <summary>
        /// 从小到大冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="reverse">是否倒序</param>
        /// <returns></returns>
        public static T[] BubbleSorting<T>(this T[] arr, bool reverse = false) where T:IComparable
        {
            for (int i = 0; i < arr.Length; i++)
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
    }
}
