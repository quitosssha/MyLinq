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