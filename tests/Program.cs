using CollectionsBench.Benchmark;

var rows = CollectionBenchmarks.Run(300, 100, 2);
if (rows.Count != 4 || rows.Select(r => r.FoundCount).Distinct().Count() != 1 || rows[0].FoundCount != 50)
    throw new Exception("Benchmarks must use equivalent deterministic queries.");
Console.WriteLine("Collection benchmark checks passed.");
