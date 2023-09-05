using BenchmarkDotNet.Running;
using StringBenchmarks.Benchmarks;

//BenchmarkRunner.Run<SimpleAppendBenchmark>();
//BenchmarkRunner.Run<LongRunAppendBenchmark>();
BenchmarkRunner.Run<InsertFullStackBenchmark>();
//BenchmarkRunner.Run<InsertShortStackBenchmark>();
