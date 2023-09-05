using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringBenchmarks.Benchmarks;

[MemoryDiagnoser]
public class InsertShortStackBenchmark:IDisposable
{
    private readonly StringBuilder _stringBuilder;
    private readonly AnotherOneStringBuilder _anotherOneStringBuilder;

    public InsertShortStackBenchmark()
    {
        _stringBuilder = new StringBuilder();
        _anotherOneStringBuilder = new AnotherOneStringBuilder();
    }
    [Benchmark]
    public string Benchmark_StringBuilder_Insert()
    {
        return _stringBuilder
            .Clear()
            .Append("begin")
            .Append(" end")
            .Insert(5, " middle")
            .ToString();
    }

    [Benchmark]
    public string Benchmark_AnotherOneStringBuilder_Insert()
    {
        return _anotherOneStringBuilder
            .Clear()
            .Append("begin")
            .Append(" end")
            .Insert(5, " middle")
            .ToString();
    }

    public void Dispose()
    {
        _anotherOneStringBuilder.Dispose();
    }
}