namespace AnotherOneStringBuilderTests;

public class ClearTests
{
    [Fact]
    public void ClearTest_Simple_Positive()
    {
        //arrange
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
            .Append("Hello, world!");

        //act
        built.Clear();

        //assert
        built.ToString()
            .Should()
            .Be(string.Empty);
    }

    [Fact]
    public void ClearTest_IfEmpty_Positive()
    {
        //arrange
        using var sb = new AnotherOneStringBuilder();

        //act
        sb.Clear();

        //assert
        sb.ToString()
            .Should()
            .Be(string.Empty);
    }

    [Fact]
    public void ClearTest_ClearTwice_Positive()
    {
        //arrange
        using var sb = new AnotherOneStringBuilder();
        sb
            .Append("My name ")
            .Append("is  ")
            .Append("Dmitry ")
            .Append("Drelin. ")
            .Append("I am ")
            .Append("41 years old. ")
            .Append("I live in Moscow, ")
            .Append("Russia. ")
            .Append("Hello, world!");

        //act
        sb.Clear();
        sb.Clear();

        //assert
        sb.ToString()
            .Should()
            .Be(string.Empty);
    }

    [Fact]
    public void ClearTest_ClearAndBuildTwice_Positive()
    {
        //arrange
        using var sb = new AnotherOneStringBuilder();
        
        //act

        sb
            .Append("My name ")
            .Append("is  ")
            .Append("Dmitry ")
            .Append("Drelin. ")
            .Append("I am ")
            .Append("41 years old. ")
            .Append("I live in Moscow, ")
            .Append("Russia. ")
            .Append("Hello, world!");
        sb.Clear();
        
        sb
            .Append("My name ")
            .Append("is  ")
            .Append("Dmitry ")
            .Append("Drelin. ")
            .Append("I am ")
            .Append("41 years old. ")
            .Append("I live in Moscow, ")
            .Append("Russia. ")
            .Append("Hello, world!");
        sb.Clear();

        //assert
        sb.ToString()
            .Should()
            .Be(string.Empty);
    }
}