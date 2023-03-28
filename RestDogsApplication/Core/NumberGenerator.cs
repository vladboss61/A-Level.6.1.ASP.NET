using System;

namespace RestDogsApplication.Core;

public sealed class NumberGenerator
{
    private readonly int random;

    public NumberGenerator()
    {
        random = new Random().Next(450);
    }

    public int GetNumber()
    {
        return random;
    }
}
