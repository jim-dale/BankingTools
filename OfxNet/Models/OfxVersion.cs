using System;

namespace OfxNet
{
    public struct OfxVersion : IEquatable<OfxVersion>
    {
        public static readonly OfxVersion InvalidHeader = new OfxVersion(-1, -1, -1);
        public static readonly OfxVersion HeaderV1 = new OfxVersion(1, 0, 0);

        public int Major { get; }
        public int Minor { get; }
        public int Revision { get; }

        public OfxVersion(int major, int minor, int revision)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
        }
        public override bool Equals(object obj) => (obj is OfxVersion other) && Equals(other);

        public bool Equals(OfxVersion other)
        {
            return (Major == other.Major)
                && (Minor == other.Minor)
                && (Revision == other.Revision);
        }

        public static bool operator ==(OfxVersion left, OfxVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OfxVersion left, OfxVersion right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Major, Minor, Revision);
        }
    }
}
