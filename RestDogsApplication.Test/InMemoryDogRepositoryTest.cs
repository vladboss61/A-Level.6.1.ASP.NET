using RestDogsApplication.Core;
using RestDogsApplication.Models;
using System.Threading.Tasks;
using Xunit;

namespace RestDogsApplication.Test;

public class InMemoryDogRepositoryTest
{
    [Theory]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    public static async Task CreateDogAsync_ShouldCreateDogINMemoryRepositoryAsync(int expectedItems, int count)
    {
        Dog dog = new Dog();

        //Act
        var dogRepository = new InMemoryDogRepository();

        for (int i = 0; i < count; i++)
        {
            await dogRepository.CreateDogAsync(dog);
        }

        var actualDogs = await dogRepository.GetDogsAsync();

        //Assert
        Assert.Equal(expectedItems, actualDogs.Length);
    }
}
