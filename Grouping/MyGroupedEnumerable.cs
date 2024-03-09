using System.Collections;

namespace MyLinq.Grouping;

public partial class MyGroupedEnumerable<TSource, TKey> : IEnumerable<IMyGrouping<TKey, TSource>>
{
    private readonly IEnumerable<TSource> collection;
    private readonly Func<TSource, TKey> keySelector;

    public MyGroupedEnumerable(IEnumerable<TSource> collection, Func<TSource, TKey> keySelector)
    {
        this.collection = collection;
        this.keySelector = keySelector;
    }

    public IEnumerator<IMyGrouping<TKey, TSource>> GetEnumerator()
        => MyLookup<TKey, TSource>.Create(collection, keySelector).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public partial class MyGroupedEnumerable<TSource, TKey, TElement> : IEnumerable<IMyGrouping<TKey, TElement>>
{
    private readonly IEnumerable<TSource> collection;
    private readonly Func<TSource, TKey> keySelector;
    private readonly Func<TSource, TElement> itemSelector;

    public MyGroupedEnumerable(
        IEnumerable<TSource> collection, 
        Func<TSource, TKey> keySelector, 
        Func<TSource, TElement> itemSelector)
    {
        this.collection = collection;
        this.keySelector = keySelector;
        this.itemSelector = itemSelector;
    }

    public IEnumerator<IMyGrouping<TKey, TElement>> GetEnumerator()
        => MyLookup<TKey, TElement>.Create(collection, keySelector, itemSelector).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}