namespace ContactsApp.Extensions;

public static class BoolExtensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    public static string IsPrimaryAddress(this bool value) => value ? "Primary" : "Secondary";
}
