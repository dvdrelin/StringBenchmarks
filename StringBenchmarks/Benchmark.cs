using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringBenchmarks;

[MemoryDiagnoser]
public class Benchmark
{

    public IEnumerable<string[]> Values()
    {
        yield return new[] { "Hello", ", World!", "\r\n", "My ", "Name ", "is", " Dima", "!" };
        yield return Enumerable.Range(0, 33).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();//[0]x4
        yield return Enumerable.Range(0, 133).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();//[0]x4x4 == [1]x4+1
    }

    [Benchmark]
    [ArgumentsSource(nameof(Values))]
    public string Benchmark_StringBuilder_100_Iterations(string[] values)
    {
        var sb=new StringBuilder();
        for (int i = 0; i < 100; i++)
        {
            sb.Append(InternalStringBuilder(values));
        }
        return sb.ToString();
    }

    [Benchmark]
    [ArgumentsSource(nameof(Values))]
    public string Benchmark_AnotherOneStringBuilder_100_Iterations(string[] values)
    {

        using var sb = new AnotherOneStringBuilder();
        for (int i = 0; i < 100; i++)
        {
            sb.Append(InternalAnotherOneStringBuilder(values));
        }
        return sb.ToString();
    }

    internal static string InternalStringBuilder(string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values) sb.Append(value);
        return sb.ToString();
    }
    internal static string InternalAnotherOneStringBuilder(string[] values)
    {
        using var sb = new AnotherOneStringBuilder();
        foreach (var value in values) sb.Append(value);
        return sb.ToString();
    }
}