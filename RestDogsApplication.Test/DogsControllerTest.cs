namespace RestDogsApplication.Test;

using Microsoft.AspNetCore.Mvc;
using Moq;
using RestDogsApplication.Controllers;
using RestDogsApplication.Core;
using RestDogsApplication.Models;
using System;
using System.Threading.Tasks;
using Xunit;

public class DogsControllerTest
{
    [Theory]
    [InlineData(200, "Tommy")]
    [InlineData(200, "Teddy")]
    public async Task GetDogsAsync_ShouldReturnDogsSuccessfullyAsync(int expectedStatus, string expectedName)
    {
        //Arrange
        var expectedDogs = new Dog[] {
            new Dog()
            {
                Age = 1,
                Name = expectedName,
                Description = "Description",
                DateOfBorn = DateTime.Now
            }
        };

        var dogRepositoryMock = new Mock<IDogRepository>();

        dogRepositoryMock.Setup(x => x.GetDogsAsync())
            .ReturnsAsync(expectedDogs);

        //Act
        var controller = new DogsController(dogRepositoryMock.Object);
        IActionResult result = await controller.GetDogsAsync();

        //Assert
        var actualOkObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedStatus, actualOkObjectResult.StatusCode);
        var actualDogs = Assert.IsType<Dog[]>(actualOkObjectResult.Value);

        Assert.Equal(expectedDogs.Length, actualDogs.Length);
        Assert.Equal(expectedName, actualDogs[0].Name);

        dogRepositoryMock.Verify(x => x.GetDogsAsync(), Times.Once);
        dogRepositoryMock.Verify(x => x.CreateDogAsync(It.IsAny<Dog>()), Times.Never);
    }

    [Theory]
    [InlineData(201)]
    public async Task CreateDogAsync_ShouldCreateDogSuccessfullyAsync(int expectedStatusCode)
    {
        //Arrange
        Dog expectedDog =
            new Dog()
            {
                Age = 1,
                Name = "Some",
                Description = "Description",
                DateOfBorn = DateTime.Now
            };

        var dogRepositoryMock = new Mock<IDogRepository>();

        dogRepositoryMock
            .Setup(x => x.CreateDogAsync(It.IsAny<Dog>()))
            .Returns(Task.CompletedTask);

        //Act
        var controller = new DogsController(dogRepositoryMock.Object);

        var actionResult = await controller.CreateDogAsync(expectedDog);

        //Assert
        var actualStatusCodeResult = Assert.IsType<StatusCodeResult>(actionResult);
        Assert.Equal(expectedStatusCode, actualStatusCodeResult.StatusCode);

        dogRepositoryMock.Verify(x => x.CreateDogAsync(It.IsAny<Dog>()), Times.Once);
        dogRepositoryMock.Verify(x => x.GetDogsAsync(), Times.Never);
    }
}