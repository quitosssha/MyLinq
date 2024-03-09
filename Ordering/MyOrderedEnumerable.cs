using System.Collections;

namespace MyLinq;

public class MyOrderedEnumerable<TSource, TKey> : IEnumerable<TSource> where TKey : IComparable<TKey>
{
    private readonly IEnumerable<TSource> collection;
    private readonly Func<TSource, TKey> keySelector;
    private bool descending;

    public MyOrderedEnumerable(IEnumerable<TSource> collection, Func<TSource, TKey> keySelector, bool descending)
    {
        this.collection = collection;
        this.keySelector = keySelector;
        this.descending = descending;
    }

    public IEnumerator<TSource> GetEnumerator()
        => SortedEnumerable<TSource, TKey>.Create(collection, keySelector, descending).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
