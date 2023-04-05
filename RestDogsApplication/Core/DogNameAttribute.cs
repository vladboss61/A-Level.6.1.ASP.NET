using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RestDogsApplication.Core;

public class DogNameAttribute : ValidationAttribute
{
    private readonly string[] _allowedNames;

    public DogNameAttribute(string[] allowedNames)
    {
        _allowedNames = allowedNames;
    }

    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }

        string strName = value as string;

        if (strName is not null)
        {
            return _allowedNames.Contains(value.ToString());
        }

        return false;
    }
}
