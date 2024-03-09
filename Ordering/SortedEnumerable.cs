using System.Collections;

namespace MyLinq;

public class SortedEnumerable<TSource, TKey> : IEnumerable<TSource> where TKey : IComparable<TKey>
{
    private List<TSource> sortedCollection;


    public static SortedEnumerable<TSource, TKey> Create(
        IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector,
        bool descending)
    {
        SortedEnumerable<TSource, TKey> sortedEnumerable = new();
        foreach (TSource item in collection)
        {
            sortedEnumerable.Insert(item, keySelector, descending);
        }
        return sortedEnumerable;
    }

    private SortedEnumerable()
    {
        sortedCollection = new List<TSource>();
    }

    public IEnumerator<TSource> GetEnumerator()
    {
        foreach (TSource item in sortedCollection)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Insert(TSource item, Func<TSource, TKey> keySelector, bool descending)
    {
        TKey key = keySelector(item);

        if (key != null)
        {
            if (sortedCollection.Count == 0)
                sortedCollection.Add(item);

            for (int i = 0; i < sortedCollection.Count; i++)
            {
                var keyToCompare = keySelector(sortedCollection[i]);

                if (key.CompareTo(keyToCompare) > 0 && !descending)
                {
                    sortedCollection.Insert(i, item);
                    break;
                }

                if (key.CompareTo(keyToCompare) <= 0 && descending)
                {
                    sortedCollection.Insert(i, item);
                    break;
                }
            }
        }
    }
}
