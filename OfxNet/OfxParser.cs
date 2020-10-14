using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OfxNet
{
    public static class OfxParser
    {
        /// <summary>
        /// Parses an OFX version string. The expected format is 3 digits - [Major][Minor][Revision] e.g. 100.
        /// </summary>
        /// <param name="str">A string containing the version number to convert.</param>
        /// <returns></returns>
        public static OfxVersion ParseVersion(string str)
        {
            var result = TryParseVersion(str);
            if (result == OfxVersion.InvalidHeader)
            {
                throw new SgmlParseException("Invalid OFX version number.");
            }

            return result;
        }

        /// <summary>
        /// Try to parse an OFX version string. The expected format is 3 digits - [Major][Minor][Revision] e.g. 100.
        /// </summary>
        /// <param name="str">A string containing the version number to convert.</param>
        /// <returns></returns>
        public static OfxVersion TryParseVersion(string str)
        {
            var result = OfxVersion.InvalidHeader;

            if (string.IsNullOrWhiteSpace(str) == false && str.Length == 3)
            {
                if (TryGetDigitValue(str[0], out int major)
                    && TryGetDigitValue(str[1], out int minor)
                    && TryGetDigitValue(str[2], out int revision))
                {
                    result = new OfxVersion(major, minor, revision);
                }
            }

            return result;
        }

        public static DateTimeOffset? ParseNullableDateTime(string value)
        {
            DateTimeOffset? result = null;

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                result = ParseDateTime(value);
            }

            return result;
        }

        public static DateTimeOffset ParseDateTime(string value)
        {
            if (TryParseDateTimeOffset(value, OfxConstants.DefaultDateTimeStyles, out DateTimeOffset result) == false)
            {
                throw new FormatException("String was not recognized as a valid DateTimeOffset.");
            }

            return result;
        }

        public static OfxAccountType ParseAccountType(string value)
        {
            return (OfxAccountType)Enum.Parse(typeof(OfxAccountType), value, true);
        }

        public static OfxSeverity ParseSeverity(string value)
        {
            return (OfxSeverity)Enum.Parse(typeof(OfxSeverity), value, true);
        }

        public static OfxTransactionType ParseTransactionType(string value)
        {
            return (OfxTransactionType)Enum.Parse(typeof(OfxTransactionType), value, true);
        }

        public static OfxCorrectiveAction ParseCorrectiveAction(string value)
        {
            return string.IsNullOrEmpty(value)
                ? OfxCorrectiveAction.NotSet
                : (OfxCorrectiveAction)Enum.Parse(typeof(OfxCorrectiveAction), value, true);
        }

        #region Private methods
        private static bool TryGetDigitValue(char ch, out int result)
        {
            var success = char.IsDigit(ch);
            result = success ? (ch - '0') : default;

            return success;
        }

        private static bool TryParseDateTimeOffset(string str, DateTimeStyles style, out DateTimeOffset result)
        {
            // Remove optional time zone name from string to be parsed
            var noTimeZoneName = Regex.Replace(str, OfxConstants.TimeZoneRegexPattern, OfxConstants.TimeZoneReplacement);

            return DateTimeOffset.TryParseExact(noTimeZoneName,
                OfxConstants.DateTimeFormats,
                CultureInfo.InvariantCulture,
                style,
                out result);
        }
        #endregion
    }
}
