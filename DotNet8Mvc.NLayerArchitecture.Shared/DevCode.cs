namespace DotNet8Mvc.NLayerArchitecture.Shared;

public static class DevCode
{
    public static bool IsNullOrEmpty(this string str)
    {
        return String.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}