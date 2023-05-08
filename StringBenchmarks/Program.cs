using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

BenchmarkRunner.Run<Benchmark>();
//Console.WriteLine(Benchmark.Test_StringCreate());

[MemoryDiagnoser]
public class Benchmark
{
    private const string Hello = "Hello";
    private const string World = ", world!";

    [Benchmark]
    public string Test_StringBuilder()
    {
        var sb = new StringBuilder();
        sb.Append(Hello);
        sb.Append(World);
        return sb.ToString();
    }
    
    [Benchmark]
    public string Test_StringCreate()
    {
        return string.Create(
            Hello.Length + World.Length,
            (Hello, World),
            (result, valueTuple) =>
            {
                valueTuple.Hello.AsSpan().CopyTo(result);
                World.AsSpan().CopyTo(result.Slice(Hello.Length));
            });
    }
}