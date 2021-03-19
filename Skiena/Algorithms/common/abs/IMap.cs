using System;
using System.Collections.Generic;

namespace Algorithms.common.abs
{
    public interface IMap<TKey, TValue> where TKey : IComparable<TKey>, IEnumerable<TKey>
    {
        bool ContainsKey(TKey key);

        TValue GetValue(TKey key);

        TValue Min();

        TValue Max();

        TKey Predecessor(TKey key);

        TKey Successor(TKey key);

        void Insert(TKey key, TValue value);

        void Delete(TKey key);
    }
}
