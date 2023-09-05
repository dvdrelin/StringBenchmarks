using BenchmarkDotNet.Attributes;

namespace StringBenchmarks.Benchmarks;

[MemoryDiagnoser]
public class LongRunAppendBenchmark
{
    public IEnumerable<string[]> LongRunsValues()
    {
        yield return Enumerable.Range(0, 25).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();
        yield return Enumerable.Range(0, 100).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();//[0]x4
        yield return Enumerable.Range(0, 401).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();//[0]x4x4 == [1]x4+1
    }

    [Benchmark]
    [ArgumentsSource(nameof(LongRunsValues))]
    public string Benchmark_StringBuilder_LongRuns(string[] values) => SimpleAppendBenchmark.InternalStringBuilder(values);

    [Benchmark]
    [ArgumentsSource(nameof(LongRunsValues))]
    public string Benchmark_AnotherOneStringBuilder_LongRuns(string[] values) => SimpleAppendBenchmark.InternalAnotherOneStringBuilder(values);
}