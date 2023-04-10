using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using RestDogsApplication.Controllers;
using RestDogsApplication.Core;
using RestDogsApplication.Infrastructure;
using System;
using Xunit;

namespace RestDogsApplication.Test;

public class ConfigControllerTest
{
    [Theory]
    [InlineData(200, LogLevel.Critical, "Error", "RandomNumberController::GetConfig is executed.")]
    [InlineData(200, LogLevel.Information, "Other", "RandomNumberController::GetConfig is executed Info.")]
    public void GetConfig_ShouldReturnConfigurationAndLogErrorMessageSuccessully(
        int expectedStatus,
        LogLevel expectedLogLevel,
        string expectedLogState,
        string expectedErrorMessage)
    {
        //Arrange
        var generator = new NumberGenerator(); // Not Mockable

        var expectedAppConfiguration = new AppConfiguration() 
        {
            ConnectionString = "Long ConnectionString",
            LogState = expectedLogState
        };

        var loggerMock = new Mock<ILogger<ConfigController>>();

        loggerMock.Setup(x => x.Log(
            It.IsAny<LogLevel>(),
            It.IsAny<EventId>(),
            It.IsAny<ConfigController>(),
            It.IsAny<Exception>(),
            It.IsAny<Func<ConfigController, Exception, string>>()));

        var optionsMock = new Mock<IOptions<AppConfiguration>>();

        optionsMock
            .SetupGet(x => x.Value)
            .Returns(expectedAppConfiguration);

        //Act
        var configController = new ConfigController(
            generator,
            loggerMock.Object,
            optionsMock.Object);

        var configResult = configController.GetConfig();
        var actualConfigOkObjectResult = configResult as OkObjectResult;

        //Assert
        Assert.NotNull(actualConfigOkObjectResult);
        Assert.NotNull(actualConfigOkObjectResult.StatusCode);
        Assert.Equal(expectedStatus, actualConfigOkObjectResult.StatusCode);

        loggerMock.Verify(logger => logger.Log(
            It.Is<LogLevel>(logLevel => logLevel == expectedLogLevel),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == expectedErrorMessage),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
        Times.Once);
    }
}
