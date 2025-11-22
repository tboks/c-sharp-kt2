using System;

namespace App.Topics.Operators.T2_2_VersionLite
{
    public class VersionLite : IComparable<VersionLite>
    {
        public int Major { get; }
        public int Minor { get; }
        public int Patch { get; }

        public VersionLite(int major, int minor, int patch)
        {
            if (major < 0) throw new ArgumentOutOfRangeException(nameof(major));
            if (minor < 0) throw new ArgumentOutOfRangeException(nameof(minor));
            if (patch < 0) throw new ArgumentOutOfRangeException(nameof(patch));

            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public int CompareTo(VersionLite other)
        {
            if (other is null) return 1;

            int majorComparison = Major.CompareTo(other.Major);
            if (majorComparison != 0) return majorComparison;

            int minorComparison = Minor.CompareTo(other.Minor);
            if (minorComparison != 0) return minorComparison;

            return Patch.CompareTo(other.Patch);
        }

        public static bool operator <(VersionLite left, VersionLite right)
        {
            if (left is null) return right is not null;
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(VersionLite left, VersionLite right)
        {
            if (left is null) return false;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(VersionLite left, VersionLite right)
        {
            if (left is null) return true;
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(VersionLite left, VersionLite right)
        {
            if (left is null) return right is null;
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(VersionLite left, VersionLite right)
        {
            if (left is null) return right is null;
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(VersionLite left, VersionLite right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is VersionLite other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Major, Minor, Patch);
        }
    }
}