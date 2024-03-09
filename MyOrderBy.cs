﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq;

public static partial class MyLinq
{
    public static IEnumerable<TSource> MyOrderBy<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector)
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: false);

    public static IEnumerable<TSource> MyOrderByDescending<TSource, TKey>
        (this IEnumerable<TSource> collection,
        Func<TSource, TKey> keySelector)
            => new MyOrderedEnumerable<TSource, TKey>(collection, keySelector, descending: true);
}

public class MyOrderedEnumerable<TSource, TKey> : IEnumerable<TSource>
{
    private readonly IEnumerable<TSource> collection;
    private readonly Func<TSource, TKey> keySelector;
    private bool descending;

    public MyOrderedEnumerable(IEnumerable<TSource> collection, Func<TSource, TKey> keySelector, bool descending)
    {
        this.collection = collection;
        this.keySelector = keySelector;
        this.descending = descending;
    }

    public IEnumerator<TSource> GetEnumerator()
        => MySortedEnumerable<TSource, TKey>.Create(collection, keySelector, descending).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}