using System;

namespace RestDogsApplication.Core;

internal static class StringsAlgs
{
    public static string RemoveDuplicateChars(string input)
    {
        if (input == null)
        {
            throw new InvalidOperationException();
        }

        string table = string.Empty;
        string result = string.Empty;

        foreach (char value in input)
        {
            if (table.IndexOf(value) == -1)
            {
                table += value;
                result += value;
            }
        }
        return result;
    }
}
