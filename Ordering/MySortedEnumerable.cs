using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Ordering;

public class MySortedEnumerable<TSource, TKey> : IEnumerable<TSource>
{
    private List<TSource> sortedList;


    public static MySortedEnumerable<TSource, TKey> Create(
        IEnumerable<TSource> collection, 
        Func<TSource, TKey> keySelector, 
        bool descending)
    {
        MySortedEnumerable<TSource, TKey> sortedEnumerable = new();
        foreach (TSource item in collection)
        {
            TKey key = keySelector(item);
            if (key != null)

        }
        return sortedEnumerable;
    }

    private MySortedEnumerable()
    {
        sortedList = new List<TSource>();
    }

    public IEnumerator<TSource> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
