namespace OfxNet;

using System;

/// <summary>
/// OFX version structure.
/// </summary>
/// <param name="major">The OFX major version number.</param>
/// <param name="minor">The OFX minor version number.</param>
/// <param name="revision">The OFX revision number.</param>
public readonly struct OfxVersion(int major, int minor, int revision)
    : IEquatable<OfxVersion>
{
    /// <summary>
    /// A read-only instance of the <see cref="OfxVersion"/> structure whose value represents an invalid value.
    /// </summary>
    public static readonly OfxVersion InvalidHeader = new(-1, -1, -1);

    /// <summary>
    /// The OFX standard version number.
    /// </summary>
    public static readonly OfxVersion HeaderV1 = new(1, 0, 0);

    /// <summary>
    /// Gets the major version number.
    /// </summary>
    public int Major { get; } = major;

    /// <summary>
    /// Gets the minor version number.
    /// </summary>
    public int Minor { get; } = minor;

    /// <summary>
    /// Gets the revision number.
    /// </summary>
    public int Revision { get; } = revision;

    public static bool operator ==(OfxVersion left, OfxVersion right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OfxVersion left, OfxVersion right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => (obj is OfxVersion other) && this.Equals(other);

    /// <inheritdoc/>
    public bool Equals(OfxVersion other)
    {
        return (this.Major == other.Major)
            && (this.Minor == other.Minor)
            && (this.Revision == other.Revision);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Major, this.Minor, this.Revision);
    }
}
