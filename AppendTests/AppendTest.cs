using FluentAssertions;
using StringBenchmarks;

namespace AppendTests
{
    public class AppendTest
    {
        [Fact]
        public void AppendTest_SimpleAppend_Positive()
        {
            using var sb = new AnotherOneStringBuilder();
            var built = sb
                .Append("My name ")
                .Append("is  ")
                .Append("Dmitry ")
                .Append("Drelin. ")
                .Append("I am ")
                .Append("41 years old. ")
                .Append("I live in Moscow, ")
                .Append("Russia. ")
                .Append("Hello, world!")
                .ToString();

            built
                .Should()
                .Be("My name is  Dmitry Drelin. I am 41 years old. I live in Moscow, Russia. Hello, world!");
        }
    }
}