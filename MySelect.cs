namespace MyLinq;

public static partial class MyLinq
{
    public static IEnumerable<TOut> MySelect<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> selector)
    {
        foreach (var item in source)
            yield return selector(item);
    }
}
