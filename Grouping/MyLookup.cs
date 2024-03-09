using System.Collections;

namespace MyLinq.Grouping;

public class MyLookup<TKey, TElement> : IEnumerable<IMyGrouping<TKey, TElement>>
{
    private MyGrouping<TKey, TElement>[] groupings;
    private MyGrouping<TKey, TElement>? lastGrouping;
    private int count;

    public static MyLookup<TKey, TElement> Create(IEnumerable<TElement> collection, Func<TElement, TKey> keySelector)
    {
        MyLookup<TKey, TElement> lookup = new();
        foreach (TElement item in collection)
        {
            TKey key = keySelector(item);
            if (key != null)
                lookup.GetGrouping(key).Add(item);
        }
        return lookup;
    }

    public static MyLookup<TKey, TElement> Create<TSource>(
        IEnumerable<TSource> collection, 
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> itemSelector)
    {
        MyLookup<TKey, TElement> lookup = new();
        foreach (TSource item in collection)
        {
            TKey key = keySelector(item);
            if (key != null)
                lookup.GetGrouping(key).Add(itemSelector(item));
        }
        return lookup;
    }


    private MyLookup()
    {
        groupings = new MyGrouping<TKey, TElement>[4];
    }

    private int GetInternalHashCode(TKey key)
        => key == null ? 0 : key.GetHashCode();

    public MyGrouping<TKey, TElement> GetGrouping(TKey key)
    {
        var hashCode = Math.Abs(GetInternalHashCode(key));
        for (MyGrouping<TKey, TElement>? gr = groupings[(uint)hashCode % groupings.Length]; gr != null; gr = gr.hashNext)
        {
            if (gr.HashCode == hashCode && gr.Key!.Equals(key))
                return gr;
        }

        if (groupings.Length == count)
            Resize();

        int index = hashCode % groupings.Length;
        MyGrouping<TKey, TElement> g = new(key, hashCode);
        g.hashNext = groupings[index];
        groupings[index] = g;
        if (lastGrouping == null)
            g.next = g;
        else
        {
            g.next = lastGrouping.next;
            lastGrouping.next = g;
        }

        lastGrouping = g;
        count++;
        return g;
    }

    public IEnumerator<IMyGrouping<TKey, TElement>> GetEnumerator()
    {
        MyGrouping<TKey, TElement>? g = lastGrouping;

        if (g != null)
        {
            do
            {
                g = g.next!;
                yield return g;
            }
            while (g != lastGrouping);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Resize()
    {
        int newSize = count * 2;
        var newGroupings = new MyGrouping<TKey, TElement>[newSize];
        MyGrouping<TKey, TElement> g = lastGrouping!;
        do
        {
            g = g.next!;
            int index = g.HashCode % newSize;
            g.hashNext = newGroupings[index];
            newGroupings[index] = g;
        }
        while (g != lastGrouping);

        groupings = newGroupings;
    }
}
