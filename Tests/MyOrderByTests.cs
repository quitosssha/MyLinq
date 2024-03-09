using NUnit.Framework;

namespace MyLinq.Tests;

[TestFixture]
internal static class MyOrderByTests
{
    [Test]
    public static void EmptyCollection()
    {
        var col = new int[0];
        col.OrderBy(x => x);
    }

    [Test]
    public static void FilledIntCollection()
    {
        var col = new int[] { 3, 1, 2,  5, 5, 0, 9 };
        col.Check(x => x);
    }

    [Test]
    public static void UsersClassCollection()
    {
        var col = new Student[] { new("Bob"), new("Andrew"), new("Chan") };
        col.Check(x => x.Name);
    }

    private static void Check<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> keySelector)
        where TKey : IComparable<TKey>
    {
        Assert.AreEqual(collection.MyOrderBy(keySelector), collection.MyOrderBy(keySelector));
        Assert.AreEqual(collection.MyOrderByDescending(keySelector), collection.MyOrderByDescending(keySelector));
    }
}
