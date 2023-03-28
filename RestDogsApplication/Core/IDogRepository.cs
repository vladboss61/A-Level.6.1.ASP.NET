using System.Threading.Tasks;
using RestDogsApplication.Models;

namespace RestDogsApplication.Core;

public interface IDogRepository
{
    public Task<Dog[]> GetDogsAsync();

    public Task CreateDogAsync(Dog dog);

    public Task DeleteDogAsync(string name);
}
