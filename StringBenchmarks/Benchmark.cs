using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Benchmark
{
    
    public IEnumerable<string[]> Values()
    {
        yield return new[] { "Hello", ", World!", "\r\n", "My ", "Name ", "is", " Dima", "!" };
        yield return Enumerable.Range(0, 33).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();
        yield return Enumerable.Range(0, 100).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();
        //yield return Enumerable.Range(0, 300).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();
        //yield return Enumerable.Range(0, 700).Select(_ => "abcdefghijklmnopqrstuvwxyz").ToArray();
        //yield return Enumerable.Range(0, 1000).Select(x => new string('a',x)).ToArray();
    }

    [Benchmark] [ArgumentsSource(nameof(Values))]
    public string Test_StringBuilder(string[] values)
    {
        var sb = new StringBuilder();
         foreach (var value in values) sb.Append(value);
        return sb.ToString();
    }

    [Benchmark] [ArgumentsSource(nameof(Values))]
    public string Test_AnotherOneStringBuilder(string[] values)
    {
        using var sb = new AnotherOneStringBuilder();
        foreach (var value in values) sb.Append(value);
        return sb.ToString();
    }
}