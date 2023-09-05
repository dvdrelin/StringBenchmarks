
using System.Text;

namespace AnotherOneStringBuilderTests;

public class AppendTests
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

    [Fact]
    public void AppendTest_SimpleAppendChar_Positive()
    {
        using var sb = new AnotherOneStringBuilder();
        var built = sb
            .Append('D')
            .Append('m')
            .Append('i')
            .Append('t')
            .Append('r')
            .Append('y')
            .Append(' ')
            .Append('D')
            .Append('r')
            .Append('e')
            .Append('l')
            .Append('i')
            .Append('n')
            .Append('.')
            .ToString();

        built
            .Should()
            .Be("Dmitry Drelin.");
    }

    [Fact]
    public void AppendTest_AppendObject_Positive()
    {
        //arrange
        object someInt = 1;
        object someBool = true;
        object someDecimal = 0.25M;
        using var sb = new AnotherOneStringBuilder();
        var expected = new StringBuilder()
            .Append(someInt)
            .Append(someBool)
            .Append(someDecimal)
            .ToString();
        //act
        var built = sb
            .Append(someInt)
            .Append(someBool)
            .Append(someDecimal)
            .ToString();

        //assert
        built
            .Should()
            .Be(expected);
    }
}