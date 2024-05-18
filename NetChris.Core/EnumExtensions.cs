using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace NetChris.Core;

// https://stackoverflow.com/a/25109103/208990
/// <summary>
/// 
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `Enum`.
    /// </summary>
    /// <seealso href="https://stackoverflow.com/a/25109103/208990" />
    public static TAttribute? GetAttribute<TAttribute>(this Enum enumValue)
        where TAttribute : Attribute
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<TAttribute>();
    }
    
    /// <summary>
    /// Get the <see cref="DisplayAttribute.Name"/> value from an enum value.
    /// </summary>
    public static string GetDisplayName(this Enum enumValue)
    {
        string result;
        var attribute = enumValue.GetAttribute<DisplayAttribute>();

        if (attribute?.Name == null)
        {
            result = enumValue.ToString();
        }
        else
        {
            result = attribute.Name;
        }

        return result;
    }
}