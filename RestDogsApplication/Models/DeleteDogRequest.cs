using RestDogsApplication.Core;
using System.ComponentModel.DataAnnotations;

namespace RestDogsApplication.Models;

public class DeleteDogRequest
{
    public string Id { get; set; }

    [Required]
    [DogName(new string[] { "Tom", "Den" }, ErrorMessage = "You do not send the dog from allowed list.")]
    public string Name { get; set; }

    [Required]
    [MinLength(1)]
    public string[] Array { get; set; }

    public int? Age { get; set; }
}
