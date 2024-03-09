using NUnit.Framework;

namespace MyLinq.Tests;

[TestFixture]
internal static class MySelectTests
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
        col.Check(x => x * 2);
    }

    [Test]
    public static void UsersClassCollection()
    {
        var col = new Student[] { new("Alex"), new("Bob"), new("Chan") };
        col.Check(x => x.Name);
    }

    private static void Check<TIn, TOut>(this IEnumerable<TIn> collection, Func<TIn, TOut> selector)
    {
        Assert.AreEqual(collection.MySelect(selector), collection.Select(selector));
    }
}
