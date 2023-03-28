using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestDogsApplication.Models;

namespace RestDogsApplication.Core;

public sealed class InMemoryDogRepository : IDogRepository
{
    //Predefined dogs.
    private readonly List<Dog> _dogs = new List<Dog>
    {
        new Dog
        {
            Name = "Tom",
            Info = "Tom is the best dog.",
            DateOfBorn = new DateTime(2020, 11, 22),

        },
        new Dog
        {
            Name = "Ron",
            Info = "Ron is the biggest dog in the city.",
            DateOfBorn = new DateTime(2019, 9, 22)
        }
    };

    public Task<Dog[]> GetDogsAsync()
    {
        return Task.FromResult(_dogs.ToArray());
    }

    public Task CreateDogAsync(Dog dog)
    {
        _dogs.Add(dog);
        return Task.CompletedTask;
    }

    public Task DeleteDogAsync(string name)
    {
        var index = _dogs.FindIndex(x => x.Name == name);
        if (index == -1)
        {
            return Task.CompletedTask;
        }
        _dogs.RemoveAt(index);
        return Task.CompletedTask;
    }
}
