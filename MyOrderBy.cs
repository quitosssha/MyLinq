using System.Collections;

namespace MyLinq;

public static partial class MyLinq
{
    public static IEnumerable<TSource> MyOrderBy<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: false);

    public static IEnumerable<TSource> MyOrderByDescending<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: true);
}

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
        => MySortedEnumerable<TSource, TKey>.Create(collection, keySelector, descending).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
