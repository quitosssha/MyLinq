using NUnit.Framework;

namespace MyLinq.Tests;

[TestFixture]
internal static class MyGroupByTests
{
    [Test]
    public static void EmptyCollection()
    {
        var col = new int[0];
        col.Check(x => x);
    }

    [Test]
    public static void FilledIntCollection()
    {
        var col = new int[] { 1, 2, 3 };
        col.Check(x => x % 2);
    }

    [Test]
    public static void UsersClassCollection()
    {
        var col = new Student[] { new("Alex"), new("Andrew"), new("Chan") };
        col.Check(x => x.Name[0]);
    }

    private static void Check<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> keySelector)
    {
        Assert.AreEqual(collection.MyGroupBy(keySelector), collection.GroupBy(keySelector));
    }

    private static void Check<TSource, TKey, TElement>(
        this IEnumerable<TSource> collection, 
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> itemSelector)
    {
        Assert.AreEqual(
            collection.MyGroupBy(keySelector, itemSelector), 
            collection.GroupBy(keySelector, itemSelector));
    }
}
