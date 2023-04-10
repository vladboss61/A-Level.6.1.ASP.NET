using RestDogsApplication.Core;
using System;
using Xunit;

namespace RestDogsApplication.Test;

public class StringsAlgsTest
{
    [Fact]
    public void RemoveDuplicateChars_RemoveSuccessfullyCharsFromInputStringArray()
    {
        //Arrange
        string input = "one-one-tow-thee-four";
        string expectedResult = "one-twhfur";
        string expectedContainsResult = "one";

        //Act
        var actualResult = StringsAlgs.RemoveDuplicateChars(input);

        //Assert
        Assert.NotNull(actualResult);
        Assert.NotEmpty(actualResult);
        Assert.Contains(expectedContainsResult, actualResult);
        Assert.Equal(expectedResult, actualResult);
    }


    [Fact]
    public void RemoveDuplicateChars_ThrowsInvalidaOperatopnException()
    {
        //Arrange
        string input = null;

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            //Act
            var actualResult = StringsAlgs.RemoveDuplicateChars(input);
        });
    }
}
