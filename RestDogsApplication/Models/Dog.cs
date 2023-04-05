using System;
using System.ComponentModel.DataAnnotations;

namespace RestDogsApplication.Models;

public class Dog
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    [Required]
    public string Info { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 50)]
    public string Description { get; set; }

    public int Age { get; set; }

    [Required]
    public DateTime DateOfBorn { get; set; }
}
