Hi all.

This is an alternative of simple .Append() and .ToString() implementation instead of standard StringBuilder.
Benchmarks are inside. Here is the metrics:

// * Summary *

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|                       Method |       values |          Mean |        Error |       StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
|----------------------------- |------------- |--------------:|-------------:|-------------:|---------:|---------:|---------:|----------:|
|           Test_StringBuilder | String[1000] | 952,356.19 ns | 7,477.322 ns | 6,628.451 ns | 248.0469 | 248.0469 | 248.0469 | 2012677 B |
| Test_AnotherOneStringBuilder | String[1000] | 447,251.65 ns | 2,416.937 ns | 2,018.252 ns |  13.6719 |  13.6719 |  13.6719 |  999069 B |
|           Test_StringBuilder |  String[100] |   1,542.65 ns |    27.706 ns |    24.560 ns |   4.4842 |        - |        - |   14064 B |
| Test_AnotherOneStringBuilder |  String[100] |   1,006.19 ns |    15.477 ns |    14.477 ns |   1.6766 |        - |        - |    5264 B |
|           Test_StringBuilder |   String[33] |     527.84 ns |     8.428 ns |     7.038 ns |   1.3685 |        - |        - |    4296 B |
| Test_AnotherOneStringBuilder |   String[33] |     368.77 ns |     2.014 ns |     1.682 ns |   0.5684 |        - |        - |    1784 B |
|           Test_StringBuilder |    String[8] |      85.22 ns |     1.077 ns |     0.840 ns |   0.0943 |        - |        - |     296 B |
| Test_AnotherOneStringBuilder |    String[8] |      97.71 ns |     1.395 ns |     1.237 ns |   0.0408 |        - |        - |     128 B |

// * Hints *
Outliers
  Benchmark.Test_StringBuilder: Default           -> 1 outlier  was  removed (1.03 ms)
  Benchmark.Test_AnotherOneStringBuilder: Default -> 2 outliers were removed (455.74 us, 493.49 us)
  Benchmark.Test_StringBuilder: Default           -> 1 outlier  was  removed (1.71 us)
  Benchmark.Test_AnotherOneStringBuilder: Default -> 4 outliers were removed (1.09 us..1.13 us)
  Benchmark.Test_StringBuilder: Default           -> 2 outliers were removed (567.84 ns, 579.30 ns)
  Benchmark.Test_AnotherOneStringBuilder: Default -> 2 outliers were removed (388.19 ns, 391.73 ns)
  Benchmark.Test_StringBuilder: Default           -> 3 outliers were removed (93.32 ns..97.71 ns)
  Benchmark.Test_AnotherOneStringBuilder: Default -> 1 outlier  was  removed (105.84 ns)

// * Legends *
  values    : Value of the 'values' parameter
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Gen1      : GC Generation 1 collects per 1000 operations
  Gen2      : GC Generation 2 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)
