using System.ComponentModel.DataAnnotations;
using System;

namespace RazorWebApplication.Models;

public class Dog
{
    public string Name { get; set; }

    public string Info { get; set; }

    public string Description { get; set; }

    public int Age { get; set; }

    public DateTime DateOfBorn { get; set; }
}