namespace MyLinq;

public static partial class MyLinq
{
    /// <summary>
    /// Works bad. Do not use! Coming soon...
    /// </summary>
    private static IEnumerable<TSource> MyOrderBy<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector) 
        where TKey : IComparable<TKey>
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: false);

    /// <summary>
    /// Works bad. Do not use! Coming soon...
    /// </summary>
    private static IEnumerable<TSource> MyOrderByDescending<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector) 
        where TKey : IComparable<TKey>
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: true);
}