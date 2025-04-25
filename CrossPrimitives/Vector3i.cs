using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;

/// <summary>
/// Three‑component vector of 32‑bit signed integers.
/// Mirrors the API surface of <see cref="Vector3"/>.
/// </summary>
public readonly struct Vector3i(int x, int y, int z)
{
    #region Static predefined vectors

    private static readonly Vector3i _zero = new(0, 0, 0);
    private static readonly Vector3i _one = new(1, 1, 1);
    private static readonly Vector3i _minusOne = new(-1, -1, -1);
    private static readonly Vector3i _max = new(int.MaxValue, int.MaxValue, int.MaxValue);
    private static readonly Vector3i _min = new(int.MinValue, int.MinValue, int.MinValue);

    private static readonly Vector3i _up = new(0, -1, 0);
    private static readonly Vector3i _down = new(0, 1, 0);
    private static readonly Vector3i _right = new(1, 0, 0);
    private static readonly Vector3i _left = new(-1, 0, 0);
    private static readonly Vector3i _forward = new(0, 0, -1);
    private static readonly Vector3i _back = new(0, 0, 1);

    public static Vector3i Zero => _zero;
    public static Vector3i One => _one;
    public static Vector3i MinusOne => _minusOne;
    public static Vector3i Max => _max;
    public static Vector3i Min => _min;

    public static Vector3i Up => _up;
    public static Vector3i Down => _down;
    public static Vector3i Right => _right;
    public static Vector3i Left => _left;
    public static Vector3i Forward => _forward;
    public static Vector3i Back => _back;

    #endregion

    #region Fields & indexer

    public readonly int X = x;
    public readonly int Y = y;
    public readonly int Z = z;

    /// <summary>Component indexer (0 ⇒ X, 1 ⇒ Y, 2 ⇒ Z).</summary>
    public int this[int index] => index switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for {nameof(Vector3i)}.")
    };

    #endregion

    #region Component‑wise modifiers

    public Vector3i WithX(int x) => new(x, Y, Z);
    public Vector3i WithY(int y) => new(X, y, Z);
    public Vector3i WithZ(int z) => new(X, Y, z);

    #endregion

    #region Arithmetic operators (component‑wise)

    public static Vector3i operator +(Vector3i a, Vector3i b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vector3i operator -(Vector3i a, Vector3i b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

    public static Vector3i operator *(Vector3i a, Vector3i b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    public static Vector3i operator /(Vector3i a, Vector3i b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

    public static Vector3i operator *(Vector3i v, int s) => new(v.X * s, v.Y * s, v.Z * s);
    public static Vector3i operator /(Vector3i v, int s) => new(v.X / s, v.Y / s, v.Z / s);

    public static Vector3i operator *(Vector3i v, float s) =>
        new((int)MathF.Round(v.X * s), (int)MathF.Round(v.Y * s), (int)MathF.Round(v.Z * s));
    public static Vector3i operator /(Vector3i v, float s) =>
        new((int)MathF.Round(v.X / s), (int)MathF.Round(v.Y / s), (int)MathF.Round(v.Z / s));

    public static Vector3i operator *(int s, Vector3i v) => new(s * v.X, s * v.Y, s * v.Z);
    public static Vector3i operator /(int s, Vector3i v) => new(s / v.X, s / v.Y, s / v.Z);

    public static Vector3i operator *(float s, Vector3i v) =>
        new((int)MathF.Round(s * v.X), (int)MathF.Round(s * v.Y), (int)MathF.Round(s * v.Z));
    public static Vector3i operator /(float s, Vector3i v) =>
        new((int)MathF.Round(s / v.X), (int)MathF.Round(s / v.Y), (int)MathF.Round(s / v.Z));

    #endregion

    #region Unary operators

    public static Vector3i operator +(Vector3i v) => v;
    public static Vector3i operator -(Vector3i v) => new(-v.X, -v.Y, -v.Z);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector3i a, Vector3i b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    public static bool operator !=(Vector3i a, Vector3i b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector3i v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    #endregion

    #region Utility methods

    /// <summary>Euclidean length (float).</summary>
    public readonly float Length() => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));

    public readonly int LengthSquared() => X * X + Y * Y + Z * Z;

    /// <summary>Returns a normalized <see cref="Vector3"/>.</summary>
    public readonly Vector3 Normalized()
    {
        var len = Length();
        return len == 0f ? new Vector3(0f, 0f, 0f) : new Vector3(X / len, Y / len, Z / len);
    }

    public readonly int Dot(Vector3i v) => X * v.X + Y * v.Y + Z * v.Z;

    /// <summary>Cross product (integer result).</summary>
    public readonly Vector3i Cross(Vector3i v) =>
        new(
            (Y * v.Z) - (Z * v.Y),
            (Z * v.X) - (X * v.Z),
            (X * v.Y) - (Y * v.X));

    public readonly Vector3i Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

    public readonly Vector3i Clamp(Vector3i min, Vector3i max) =>
        new(Math.Clamp(X, min.X, max.X),
            Math.Clamp(Y, min.Y, max.Y),
            Math.Clamp(Z, min.Z, max.Z));

    public readonly Vector3i Clamp(int min, int max) =>
        new(Math.Clamp(X, min, max),
            Math.Clamp(Y, min, max),
            Math.Clamp(Z, min, max));

    /// <summary>Angle between vectors in radians (0…π).</summary>
    public readonly float AngleTo(Vector3i to)
    {
        var denom = Length() * to.Length();
        return denom == 0f ? 0f : MathF.Acos(Math.Clamp((float)Dot(to) / denom, -1f, 1f));
    }

    public readonly Vector3i Reflect(Vector3i normal)
    {
        var factor = 2 * Dot(normal);
        return new(factor * normal.X - X, factor * normal.Y - Y, factor * normal.Z - Z);
    }

    public readonly Vector3i Bounce(Vector3i normal) => -Reflect(normal);

    public readonly Vector3i Lerp(Vector3i to, float weight)
    {
        var nx = AdditionalMath.Lerp(X, to.X, weight);
        var ny = AdditionalMath.Lerp(Y, to.Y, weight);
        var nz = AdditionalMath.Lerp(Z, to.Z, weight);
        return new((int)MathF.Round(nx), (int)MathF.Round(ny), (int)MathF.Round(nz));
    }

    public readonly Vector3i LimitLength(int length = 1)
    {
        var sqLen = LengthSquared();
        var sqMax = length * length;
        if (sqLen == 0 || sqLen <= sqMax)
        {
            return this;
        }

        var scale = length / MathF.Sqrt(sqLen);
        return new(
            (int)MathF.Round(X * scale),
            (int)MathF.Round(Y * scale),
            (int)MathF.Round(Z * scale));
    }

    /// <summary>Spherical linear interpolation.</summary>
    public readonly Vector3i Slerp(Vector3i to, float t)
    {
        var lenA = Length();
        var lenB = to.Length();
        if (lenA == 0f || lenB == 0f)
        {
            return Lerp(to, t);
        }

        var dot = Math.Clamp((float)Dot(to) / (lenA * lenB), -1f, 1f);
        var theta = MathF.Acos(dot) * t;

        var rel = (to - this * dot).Normalized();    // Vector3, unit
        var res = (this * MathF.Cos(theta)) + (rel * MathF.Sin(theta)).AsVector3i();

        return new(
            (int)MathF.Round(res.X),
            (int)MathF.Round(res.Y),
            (int)MathF.Round(res.Z));
    }

    public readonly Vector3i Slide(Vector3i normal) => this - (Dot(normal) * normal);

    public readonly Vector3i Snapped(Vector3i step) =>
        new((int)AdditionalMath.Snapped(X, step.X),
            (int)AdditionalMath.Snapped(Y, step.Y),
            (int)AdditionalMath.Snapped(Z, step.Z));

    public readonly Vector3i Snapped(int step) =>
        new((int)AdditionalMath.Snapped(X, step),
            (int)AdditionalMath.Snapped(Y, step),
            (int)AdditionalMath.Snapped(Z, step));

    /// <summary>Returns an arbitrary integer vector orthogonal to this one.</summary>
    public readonly Vector3i Orthogonal()
    {
        var absX = Math.Abs(X);
        var absY = Math.Abs(Y);
        var absZ = Math.Abs(Z);

        return absX < absY && absX < absZ
            ? new(0, -Z, Y)
            : absY < absZ
                ? new(-Z, 0, X)
                : new(-Y, X, 0);
    }

    public readonly float Average() => (X + Y + Z) / 3f;
    public readonly void Deconstruct(out int x, out int y, out int z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    #endregion

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y}, {Z})";
}