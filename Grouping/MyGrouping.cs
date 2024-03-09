using System.Collections;

namespace MyLinq.Grouping;

public interface IMyGrouping<TKey, TElement> : IEnumerable<TElement>
{
    TKey Key { get; }
}

public class MyGrouping<TKey, TElement> : IMyGrouping<TKey, TElement>
{
    public readonly TKey Key;
    public readonly int HashCode;
    public TElement[] Elements;
    public int count;
    public MyGrouping<TKey, TElement>? hashNext;
    public MyGrouping<TKey, TElement>? next;

    public MyGrouping(TKey key, int hashCode)
    {
        Key = key;
        HashCode = hashCode;
        Elements = new TElement[1];
    }

    public void Add(TElement element)
    {
        if (Elements.Length == count)
            Array.Resize(ref Elements, count * 2);
        Elements[count++] = element;
    }

    TKey IMyGrouping<TKey, TElement>.Key => Key;

    public IEnumerator<TElement> GetEnumerator()
    {
        foreach (var e in Elements)
            yield return e;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
