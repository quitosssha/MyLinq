using NUnit.Framework;

namespace MyLinq.Tests;

[TestFixture]
internal static class MyWhereTests
{
    [Test]
    public static void EmptyCollection()
    {
        var col = new int[0];
        col.Check(x => x == 0);
    }

    [Test]
    public static void FilledIntCollection()
    {
        var col = new int[] { 1, 2, 3 };
        col.Check(x => x % 2 == 1);
    }

    [Test]
    public static void UsersClassCollection()
    {
        var col = new Student[] { new("Alex"), new("Andrew"), new("Chan") };
        col.Check(x => x.Name[0] == 'A');
    }

    private static void Check<T>(this IEnumerable<T> collection, Func<T, bool> selector)
    {
        Assert.AreEqual(collection.MyWhere(selector), collection.Where(selector));
    }
}
