namespace OfxNet;

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Utility methods to parse OFX values.
/// </summary>
public static class OfxParser
{
    /// <summary>
    /// Parses an OFX version string. The expected format is 3 digits - [Major][Minor][Revision] e.g. "100".
    /// </summary>
    /// <param name="s">The string containing the version number to convert.</param>
    /// <returns></returns>
    public static OfxVersion ParseVersion(string s)
    {
        OfxVersion result = TryParseVersion(s);
        if (result == OfxVersion.InvalidHeader)
        {
            throw new SgmlParseException("Invalid OFX version number.");
        }

        return result;
    }

    /// <summary>
    /// Try to parse an OFX version string. The expected format is 3 digits - [Major][Minor][Revision] e.g. "100".
    /// </summary>
    /// <param name="s">The string containing the version number to convert.</param>
    /// <returns></returns>
    public static OfxVersion TryParseVersion(string s)
    {
        OfxVersion result = OfxVersion.InvalidHeader;

        if (string.IsNullOrWhiteSpace(s) == false && s.Length == 3)
        {
            if (TryGetDigitValue(s[0], out int major)
                && TryGetDigitValue(s[1], out int minor)
                && TryGetDigitValue(s[2], out int revision))
            {
                result = new OfxVersion(major, minor, revision);
            }
        }

        return result;
    }

    /// <summary>
    /// Parses an OFX integer value.
    /// </summary>
    /// <param name="s">The string containing the number to convert.</param>
    /// <returns></returns>
    public static (bool NullOrWhiteSpace, bool NotInteger, int Value) ParseInteger(string? s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return (true, false, default);
        }
        if (int.TryParse(s, out int temp))
        {
            return (false, false, temp);
        }
        else
        {
            return (false, true, default);
        }
    }

    public static (bool NullOrWhiteSpace, bool NotDecimal, decimal Value) ParseDecimal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return (true, false, default);
        }
        if (decimal.TryParse(value, out decimal temp))
        {
            return (false, false, temp);
        }
        else
        {
            return (false, true, default);
        }
    }

    public static DateTimeOffset? ParseNullableDateTime(string? value)
    {
        DateTimeOffset? result = default;

        if (string.IsNullOrWhiteSpace(value) == false)
        {
            result = ParseDateTime(value);
        }

        return result;
    }

    public static DateTimeOffset ParseDateTime(string? value)
    {
        DateTimeOffset result = default;

        if (string.IsNullOrWhiteSpace(value) == false)
        {
            if (TryParseDateTimeOffset(value, OfxConstants.DefaultDateTimeStyles, out result) == false)
            {
                throw new FormatException("String was not recognized as a valid DateTimeOffset.");
            }
        }

        return result;
    }

    public static OfxAccountType ParseAccountType(string? value)
    {
        return ParseEnumString<OfxAccountType>(value);
    }

    public static OfxSeverity ParseSeverity(string? value)
    {
        return ParseEnumString<OfxSeverity>(value);
    }

    public static OfxTransactionType ParseTransactionType(string? value)
    {
        return ParseEnumString<OfxTransactionType>(value);
    }

    public static OfxCorrectiveAction ParseCorrectiveAction(string? value)
    {
        return ParseEnumString<OfxCorrectiveAction>(value);
    }

    private static bool TryGetDigitValue(char ch, out int result)
    {
        var success = char.IsDigit(ch);
        result = success ? (ch - '0') : default;

        return success;
    }

    private static bool TryParseDateTimeOffset(string str, DateTimeStyles style, out DateTimeOffset result)
    {
        // Remove possible time zone name from string to be parsed
        var noTimeZoneName = Regex.Replace(str, OfxConstants.TimeZoneRegexPattern, OfxConstants.TimeZoneReplacement);

        return DateTimeOffset.TryParseExact(noTimeZoneName,
            OfxConstants.DateTimeFormats,
            CultureInfo.InvariantCulture,
            style,
            out result);
    }

    private static EnumType ParseEnumString<EnumType>(string? value) where EnumType : Enum
    {
        EnumType result = default!;

        if (string.IsNullOrWhiteSpace(value) == false
            && Enum.IsDefined(typeof(EnumType), value))
        {
            result = (EnumType)Enum.Parse(typeof(EnumType), value, true);
        }

        return result;
    }
}
