namespace NetChris.Core;

/// <summary>
/// Extension methods for <see cref="string"/>.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Given a string, returns <c>null</c> if <paramref name="value"/> is null, empty, or whitespace.  Otherwise, the string is returned as-is.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="trimValue">Whether to trim the result if non-null, non-whitespace.  Defaults to <c>false</c></param>
    /// <returns><c>null</c> if <paramref name="value"/> is null, empty, or whitespace.  Otherwise, the string is returned as-is (with optional trimming)</returns>
    public static string? CoerceEmptyOrWhiteSpaceToNull(this string? value, bool trimValue = false)
    {
        var result = value;

        if (string.IsNullOrWhiteSpace(result))
        {
            result = null;
        }
        else if (trimValue)
        {
            result = result!.Trim();
        }

        return result;
    }
    
    /// <summary>
    /// Returns a default value if the string is null or whitespace, otherwise the original string
    /// </summary>
    public static string DefaultIfNullOrWhiteSpace(this string? value, string defaultValue) =>
        string.IsNullOrWhiteSpace(value) ? defaultValue : value!;
}