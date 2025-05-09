namespace TavernSystem.Application;

using System.Text.RegularExpressions;

public static class PersonIdValidator
{
    private static readonly Regex Regex = new(@"^[A-Z]{2}\d{4}(0[1-9]|1[0-1])(0[1-9]|1\d|2[0-8])\d{4}[A-Z]{2}$");

    public static bool IsValid(string personId)
    {
        return Regex.IsMatch(personId);
    }
}