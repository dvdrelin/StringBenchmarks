using BenchmarkDotNet.Running;
using StringBenchmarks;

BenchmarkRunner.Run<Benchmark>();
BenchmarkRunner.Run<LongRunBenchmark>();
