namespace OfxNet;

using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>Extension methods for <see cref="IOfxElement"/>.</summary>
public static class IOfxElementExtensions
{
    /// <summary>
    /// Retrieve the <see cref="DateTimeOffset"/> value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The <see cref="DateTimeOffset"/> of the requested child element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    /// <exception cref="OfxException">Thrown if the requested child element does not exist or cannot be parsed as a <see cref="DateTimeOffset"/>.</exception>
    public static DateTimeOffset GetDateTimeOffset(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);
        string value = parent.GetString(name, settings);

        try
        {
            return OfxParser.ParseDateTime(value);
        }
        catch (Exception exception)
        {
            throw new OfxException(
                $"Element '{name}' with value '{value}' could not be parsed as a {nameof(DateTimeOffset)}.",
                exception);
        }
    }

    /// <summary>
    /// Retrieve the decimal value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The <see cref="decimal"/> value of the requested child element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    /// <exception cref="OfxException">Thrown if the requested child element does not exist or cannot be parsed as a <see cref="decimal"/>.</exception>
    public static decimal GetDecimal(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string value = parent.GetString(name, settings);

        try
        {
            return decimal.Parse(value, CultureInfo.CurrentCulture);
        }
        catch (Exception exception)
        {
            throw new OfxException(
                $"Element '{name}' with value '{value}' could not be parsed as a {typeof(decimal)}.",
                exception);
        }
    }

    /// <summary>
    /// Retrieve the specified child <see cref="IOfxElement"/> element.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The requested child element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    /// <exception cref="OfxException">Thrown if the requested child element is not present.</exception>
    public static IOfxElement GetElement(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);
        IOfxElement? child = parent.Element(name, settings.TagComparer);

        return child is not null
            ? child
            : throw new OfxException($"Required element '{name}' missing from element '{parent.Name}'.");
    }

    /// <summary>
    /// Retrieve the integer value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The <see cref="int"/> value of the requested child element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    /// <exception cref="OfxException">Thrown if the requested child element does not exist or cannot be parsed as an <see cref="int"/>.</exception>
    public static int GetInt(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string value = parent.GetString(name, settings);

        try
        {
            return int.Parse(value, CultureInfo.CurrentCulture);
        }
        catch (Exception exception)
        {
            throw new OfxException(
                $"Element '{name}' with value '{value}' could not be parsed as a {typeof(int)}.",
                exception);
        }
    }

    /// <summary>
    /// Retrieves the string value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The string value of the requested child element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    /// <exception cref="OfxException">Thrown if the requested child element does not exist.</exception>
    public static string GetString(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string? value = parent.GetElement(name, settings).Value;

        if (settings.TrimValues && string.IsNullOrEmpty(value) == false)
        {
            value = value.Trim();
        }

        return value!;
    }

    /// <summary>
    /// Attempts to retrieve an enumeration of child <see cref="IOfxElement"/> elements with the specified name.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child elements to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>An enumeration of the requested child elements. An empty enumeration is returned if no such child elements exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static IEnumerable<IOfxElement> TryEnumeratElements(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);
        return parent.Elements(name, settings.TagComparer);
    }

    /// <summary>
    /// Attempts to retrieve an enumeration of child <see cref="IOfxElement"/> elements with the specified names.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="names">The names of the child elements to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>An enumeration of the requested child elements. An empty enumeration is returned if no such child elements exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static IEnumerable<IOfxElement> TryEnumeratElements(this IOfxElement parent, string[] names, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);
        return parent.Elements(names, settings.TagComparer);
    }

    /// <summary>
    /// Attempts to retrieve the <see cref="DateTimeOffset"/> value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>
    /// The <see cref="DateTimeOffset"/> of the requested child element, or <c>null</c> if the element does not exist
    /// or does not represent a <see cref="DateTimeOffset"/> value.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Intentional for try-get pattern.")]
    public static DateTimeOffset? TryGetDateTimeOffset(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string? value = parent.TryGetString(name, settings);

        try
        {
            return OfxParser.ParseNullableDateTime(value);
        }
        catch
        {
            // Intentionally swallow the exception and return null
        }

        return null;
    }

    /// <summary>
    /// Attempts to retrieve the decimal value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>
    /// The <see cref="decimal"/> value of the requested child element, or <c>null</c> if the element does not exist
    /// or does not represent a <see cref="decimal"/> value.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static decimal? TryGetDecimal(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string? value = parent.TryGetString(name, settings);

        if (value is not null)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
        }

        return null;
    }

    /// <summary>
    /// Attempts to retrieve the decimal value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>
    /// The <see cref="int"/> value of the requested child element, or <c>null</c> if the element does not exist
    /// or does not represent a <see cref="int"/> value.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static int? TryGetInt(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string? value = parent.TryGetString(name, settings);

        if (value is not null)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
        }

        return null;
    }

    /// <summary>
    /// Attempts to retrieve the specified child <see cref="IOfxElement"/> element.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The requested child element or <c>null</c> if no such child exists.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static IOfxElement? TryGetElement(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);
        return parent.Element(name, settings.TagComparer);
    }

    /// <summary>
    /// Attempts to retrieve the string value of a child element from the specified <see cref="IOfxElement"/>.
    /// </summary>
    /// <param name="parent">The parent <see cref="IOfxElement"/> containing the child element.</param>
    /// <param name="name">The name of the child element to retrieve.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> that control parsing behavior.</param>
    /// <returns>The string value of the requested child element, or <c>null</c> if the element does not exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the parent element provided is null.</exception>
    public static string? TryGetString(this IOfxElement parent, string name, OfxDocumentSettings settings)
    {
        ArgumentNullException.ThrowIfNull(parent);

        string? value = parent.TryGetElement(name, settings)?.Value;

        if (settings.TrimValues && string.IsNullOrEmpty(value) == false)
        {
            value = value.Trim();
        }

        return value;
    }
}
