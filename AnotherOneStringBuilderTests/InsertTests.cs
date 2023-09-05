namespace AnotherOneStringBuilderTests;

public class InsertTests
{
    [Fact]
    public void InsertTest_SimpleInsertAt0_Positive()
    {
        //act
        var sb = new AnotherOneStringBuilder();
        sb.Append("First");

        //arrange
        sb.Insert(0, "The ");

        //assert
        sb
            .ToString()
            .Should()
            .Be("The First");

    }

    [Fact]
    public void InsertTest_SimpleInsertLikeAppend_Positive()
    {
        //act
        var sb = new AnotherOneStringBuilder();
        const string initial = "The ";
        sb.Append(initial);

        //arrange
        sb.Insert(initial.Length, "First");

        //assert
        sb
            .ToString()
            .Should()
            .Be("The First");

    }

    [Fact]
    public void InsertTest_SimpleInsertSomewhereInMiddle_Positive()
    {
        //act
        var sb = new AnotherOneStringBuilder();
        const string initial = "Thest";
        sb.Append(initial);

        //arrange
        sb.Insert(3, " Fir");

        //assert
        sb
            .ToString()
            .Should()
            .Be("The First");

    }

}