using System.Diagnostics;

namespace CollectionsBench.Benchmark;

public sealed record BenchmarkRow(string Collection, double MedianMilliseconds, int FoundCount);

public static class CollectionBenchmarks
{
    public static IReadOnlyList<BenchmarkRow> Run(int itemCount = 15_000, int queryCount = 1_500, int repetitions = 5)
    {
        if (itemCount < 1 || queryCount < 1 || repetitions < 1) throw new ArgumentOutOfRangeException();
        var random = new Random(180);
        var values = Enumerable.Range(0, itemCount).OrderBy(_ => random.Next()).ToArray();
        var queries = Enumerable.Range(0, queryCount).Select(i => i % 2 == 0 ? values[random.Next(values.Length)] : -i - 1).ToArray();
        var list = values.ToList();
        var hash = values.ToHashSet();
        var sorted = values.Order().ToArray();
        return [
            Measure("Array · busca linear", () => queries.Count(query => Array.IndexOf(values, query) >= 0), repetitions),
            Measure("List<T> · Contains", () => queries.Count(query => list.Contains(query)), repetitions),
            Measure("HashSet<T> · Contains", () => queries.Count(query => hash.Contains(query)), repetitions),
            Measure("Array ordenado · busca binária", () => queries.Count(query => Array.BinarySearch(sorted, query) >= 0), repetitions)
        ];
    }

    private static BenchmarkRow Measure(string name, Func<int> action, int repetitions)
    {
        var times = new double[repetitions];
        var found = 0;
        for (var i = 0; i < repetitions; i++)
        {
            var watch = Stopwatch.StartNew();
            found = action();
            watch.Stop();
            times[i] = watch.Elapsed.TotalMilliseconds;
        }
        Array.Sort(times);
        return new(name, times[times.Length / 2], found);
    }
}
