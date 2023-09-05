using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringBenchmarks.Benchmarks;

[MemoryDiagnoser]
public class InsertFullStackBenchmark
{
    [Benchmark]
    public string Benchmark_StringBuilder_Insert()
    {
        var stringBuilder = new StringBuilder();
        return stringBuilder
            .Append("begin")
            .Append(" end")
            .Insert(5, " middle")
            .ToString();
    }

    [Benchmark]
    public string Benchmark_AnotherOneStringBuilder_Insert()
    {
        using var anotherOneStringBuilder = new AnotherOneStringBuilder();
        return anotherOneStringBuilder
            .Append("begin")
            .Append(" end")
            .Insert(5, " middle")
            .ToString();
    }
}