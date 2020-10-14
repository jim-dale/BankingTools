using System.Text.RegularExpressions;

namespace OfxNet
{
    public static class SgmlConstants
    {
        #region OFX SGML Header string constants
        public const string Header = "OFXHEADER";
        public const string DataHeader = "DATA";
        public const string VersionHeader = "VERSION";
        public const string SecurityHeader = "SECURITY";
        public const string EncodingHeader = "ENCODING";
        public const string CharsetHeader = "CHARSET";
        public const string CompressionHeader = "COMPRESSION";
        public const string OldFileUIDHeader = "OLDFILEUID";
        public const string NewFileUIDHeader = "NEWFILEUID";
        #endregion

        #region Regular Expression Patterns
        public const string HeaderRegexPrefix = "^";
        public const string HeaderRegexSeparator = @"\s*:\s*";
        public const string HeaderVersionRegexPattern = HeaderRegexPrefix + Header + HeaderRegexSeparator + @"(\d{3})" + @"\s*$";
        public const string HeaderRegexPattern = HeaderRegexPrefix + @"(\w+)" + HeaderRegexSeparator + @"(.+)" + @"$";

        public const string OpeningTagRegexPattern = @"^\s*<([\w\.]+)>\s*$";
        public const string ClosingTagRegexPattern = @"^\s*</([\w\.]+)>\s*$";
        public const string ValueFullTagRegexPattern = @"^\s*<([\w\.]+)>(.+)</([\w\.]+)>\s*$";
        public const string ValuePartialTagRegexPattern = @"^\s*<([\w\.]+)>(.+)$";
        #endregion

        #region Regular Expression objects
        public static readonly Regex HeaderVersionRegex = new Regex(HeaderVersionRegexPattern, RegexOptions.IgnoreCase);
        public static readonly Regex HeaderRegex = new Regex(HeaderRegexPattern, RegexOptions.IgnoreCase);
        public static readonly Regex OpeningTagRegex = new Regex(OpeningTagRegexPattern, RegexOptions.IgnoreCase);
        public static readonly Regex ClosingTagRegex = new Regex(ClosingTagRegexPattern, RegexOptions.IgnoreCase);
        public static readonly Regex ValueFullTagRegex = new Regex(ValueFullTagRegexPattern, RegexOptions.IgnoreCase);
        public static readonly Regex ValuePartialTagRegex = new Regex(ValuePartialTagRegexPattern, RegexOptions.IgnoreCase);
        #endregion
    }
}
