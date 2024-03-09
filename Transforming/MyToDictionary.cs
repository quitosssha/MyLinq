using MyLinq.Grouping;

namespace MyLinq;

public static partial class MyLinq
{
    public static Dictionary<TKey, TElement> MyToDictionary<TKey, TSourceKey, TElement, TSourceElement>(
        this IEnumerable<IMyGrouping<TSourceKey, TSourceElement>> groupedCollection,
        Func<TSourceKey, TKey> keySelector,
        Func<TSourceElement[], TElement> itemSelector)
    {
        Dictionary<TKey, TElement> dict = [];
        foreach (var grouping in groupedCollection)
        {
            dict.Add(keySelector(grouping.Key), itemSelector(grouping.Elements));
        }
        return dict;
    }
}
