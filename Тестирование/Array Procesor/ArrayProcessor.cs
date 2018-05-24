using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Procesor
{
    public class ArrayProcessor
    {
       public int[] SortAndFilter(int[] a)
        {
            int[] arrey = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                arrey[i] = a[i];
            }
            int[] arr = arrey.Distinct().ToArray();
            Array.Sort(arr);
            return arr;
        }
    }
}
