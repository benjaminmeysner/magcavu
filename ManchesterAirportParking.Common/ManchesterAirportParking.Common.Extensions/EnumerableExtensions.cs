﻿namespace ManchesterAirportParking.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> SequentialGroup<T>(this IEnumerable<T> source, Func<T, T, bool> predicate)
        {
            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }

                List<T> batch = new List<T> { iterator.Current };

                while (iterator.MoveNext())
                {
                    if (!predicate(batch[^1], iterator.Current))
                    {
                        yield return batch;

                        batch = new List<T>();
                    }

                    batch.Add(iterator.Current);
                }

                if (batch.Any())
                {
                    yield return batch;
                }
            }
        }
    }
}
