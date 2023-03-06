namespace Walkers.UI.Shared;

public static class Helper
{
    public static string AddDayTag(this string fizzItem)
    {

        return $"{fizzItem}-{DateTime.Today.DayOfWeek.ToString().First().ToString().ToLowerInvariant()}";
    }
}

