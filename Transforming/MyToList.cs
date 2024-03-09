using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq;

public static partial class MyLinq
{
    public static List<T> MyToList<T>(this IEnumerable<T> collection)
    {
        List<T> list = [];

        foreach (T item in collection)
        {
            list.Add(item);
        }

        return list;
    }
}
