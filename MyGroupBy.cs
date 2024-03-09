using MyLinq.Grouping;

namespace MyLinq;

public static partial class MyLinq
{
    public static IEnumerable<IMyGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector)
            => new MyGroupedEnumerable<TSource, TKey>(collection, keySelector);

    public static IEnumerable<IMyGrouping<TKey, TElement>> MyGroupBy<TSource, TKey, TElement>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> itemSelector)
            => new MyGroupedEnumerable<TSource, TKey, TElement>(collection, keySelector, itemSelector);
}

