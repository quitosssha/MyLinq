using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq;

public static partial class MyLinq
{
    public static T[] MyToArray<T>(this IEnumerable<T> collection)
    {
        T[] array = new T[collection.Count()];
        int i = 0;

        foreach (T item in collection)
        {
            array[i++] = item;
        }

        return array;
    }
}
