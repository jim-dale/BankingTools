namespace OfxNet;

using System;
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
    /// <returns>The <see cref="OfxVersion"/>.</returns>
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
    /// <returns>The <see cref="OfxVersion"/> if successfully parsed, otherwise <see cref="OfxVersion.InvalidHeader"></see>.</returns>
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
    /// <param name="s">The string containing the number to parse.</param>
    /// <returns>The result of parsing the specified string.</returns>
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

    /// <summary>
    /// Parses an OFX decimal value.
    /// </summary>
    /// <param name="s">The string containing the decimal to parse.</param>
    /// <returns>The result of parsing the specified string.</returns>
    public static (bool NullOrWhiteSpace, bool NotDecimal, decimal Value) ParseDecimal(string? s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return (true, false, default);
        }

        if (decimal.TryParse(s, out decimal temp))
        {
            return (false, false, temp);
        }
        else
        {
            return (false, true, default);
        }
    }

    /// <summary>
    /// Parses an optional OFX datetime value.
    /// </summary>
    /// <param name="s">The string containing the datetime to parse.</param>
    /// <returns>The <see cref="DateTimeOffset"/> result of parsing the specified string.</returns>
    public static DateTimeOffset? ParseNullableDateTime(string? s)
    {
        DateTimeOffset? result = default;

        if (string.IsNullOrWhiteSpace(s) == false)
        {
            result = ParseDateTime(s);
        }

        return result;
    }

    /// <summary>
    /// Parses an OFX datetime value.
    /// </summary>
    /// <param name="s">The string containing the datetime to parse.</param>
    /// <returns>The <see cref="DateTimeOffset"/> result of parsing the specified string.</returns>
    public static DateTimeOffset ParseDateTime(string? s)
    {
        DateTimeOffset result = default;

        if (string.IsNullOrWhiteSpace(s) == false)
        {
            if (TryParseDateTimeOffset(s, OfxConstants.DefaultDateTimeStyles, out result) == false)
            {
                throw new FormatException("String was not recognized as a valid DateTimeOffset.");
            }
        }

        return result;
    }

    /// <summary>
    /// Parses an OFX account type string.
    /// </summary>
    /// <param name="s">The string containing the account type to parse.</param>
    /// <returns>The <see cref="OfxAccountType"/> result of parsing the specified string.</returns>
    public static OfxAccountType ParseAccountType(string? s)
    {
        return ParseEnumString<OfxAccountType>(s);
    }

    /// <summary>
    /// Parses an OFX error severity string.
    /// </summary>
    /// <param name="s">The string containing the error severity to parse.</param>
    /// <returns>The <see cref="OfxSeverity"/> result of parsing the specified string.</returns>
    public static OfxSeverity ParseSeverity(string? s)
    {
        return ParseEnumString<OfxSeverity>(s);
    }

    /// <summary>
    /// Parses an OFX transaction type string.
    /// </summary>
    /// <param name="s">The string containing the transation type to parse.</param>
    /// <returns>The <see cref="OfxTransactionType"/> result of parsing the specified string.</returns>
    public static OfxTransactionType ParseTransactionType(string? s)
    {
        return ParseEnumString<OfxTransactionType>(s?.ToUpperInvariant());
    }

    /// <summary>
    /// Parses an OFX corrective action string.
    /// </summary>
    /// <param name="s">The string containing the corrective action to parse.</param>
    /// <returns>The <see cref="OfxCorrectiveAction"/> result of parsing the specified string.</returns>
    public static OfxCorrectiveAction ParseCorrectiveAction(string? s)
    {
        return ParseEnumString<OfxCorrectiveAction>(s);
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

        return DateTimeOffset.TryParseExact(
            noTimeZoneName,
            OfxConstants.DateTimeFormats,
            CultureInfo.InvariantCulture,
            style,
            out result);
    }

    private static TEnum ParseEnumString<TEnum>(string? value)
        where TEnum : Enum
    {
        TEnum result = default!;

        if (string.IsNullOrWhiteSpace(value) == false
            && Enum.IsDefined(typeof(TEnum), value))
        {
            result = (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }

        return result;
    }
}
