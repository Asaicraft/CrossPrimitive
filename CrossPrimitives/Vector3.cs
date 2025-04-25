using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;

/// <summary>
/// Three‑component floating‑point vector.
/// API mirrors <see cref="Vector2"/>
/// </summary>
public readonly struct Vector3(float x, float y, float z)
{
    #region Static predefined vectors

    private static readonly Vector3 _zero = new(0f, 0f, 0f);
    private static readonly Vector3 _one = new(1f, 1f, 1f);
    private static readonly Vector3 _minusOne = new(-1f, -1f, -1f);
    private static readonly Vector3 _inf = new(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

    private static readonly Vector3 _up = new(0f, -1f, 0f);
    private static readonly Vector3 _down = new(0f, 1f, 0f);
    private static readonly Vector3 _right = new(1f, 0f, 0f);
    private static readonly Vector3 _left = new(-1f, 0f, 0f);
    private static readonly Vector3 _forward = new(0f, 0f, -1f);
    private static readonly Vector3 _back = new(0f, 0f, 1f);

    public static Vector3 Zero => _zero;
    public static Vector3 One => _one;
    public static Vector3 MinusOne => _minusOne;
    public static Vector3 Inf => _inf;

    public static Vector3 Up => _up;
    public static Vector3 Down => _down;
    public static Vector3 Right => _right;
    public static Vector3 Left => _left;
    public static Vector3 Forward => _forward;
    public static Vector3 Back => _back;

    #endregion

    #region Fields & indexer

    public readonly float X = x;
    public readonly float Y = y;
    public readonly float Z = z;

    /// <summary>Component indexer (0 ⇒ X, 1 ⇒ Y, 2 ⇒ Z).</summary>
    public float this[int index] => index switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for {nameof(Vector3)}.")
    };

    #endregion

    #region Component‑wise modifiers

    public Vector3 WithX(float x) => new(x, Y, Z);
    public Vector3 WithY(float y) => new(X, y, Z);
    public Vector3 WithZ(float z) => new(X, Y, z);

    #endregion

    #region Arithmetic operators (component‑wise)

    public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

    public static Vector3 operator *(Vector3 a, Vector3 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    public static Vector3 operator /(Vector3 a, Vector3 b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

    public static Vector3 operator *(Vector3 v, float s) => new(v.X * s, v.Y * s, v.Z * s);
    public static Vector3 operator /(Vector3 v, float s) => new(v.X / s, v.Y / s, v.Z / s);
    public static Vector3 operator *(float s, Vector3 v) => new(s * v.X, s * v.Y, s * v.Z);
    public static Vector3 operator /(float s, Vector3 v) => new(s / v.X, s / v.Y, s / v.Z);

    #endregion

    #region Unary operators

    public static Vector3 operator +(Vector3 v) => v;
    public static Vector3 operator -(Vector3 v) => new(-v.X, -v.Y, -v.Z);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector3 a, Vector3 b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    public static bool operator !=(Vector3 a, Vector3 b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector3 v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    #endregion

    #region Utility methods

    /// <summary>Returns the Euclidean length of the vector.</summary>
    public readonly float Length() => MathF.Sqrt(X * X + Y * Y + Z * Z);

    public readonly float LengthSquared() => X * X + Y * Y + Z * Z;

    /// <summary>Returns a normalized copy of the vector (unit length).</summary>
    public readonly Vector3 Normalized()
    {
        var len = Length();
        return len == 0 ? this : this / len;
    }

    public readonly float Dot(Vector3 v) => X * v.X + Y * v.Y + Z * v.Z;

    /// <summary>Vector (cross) product.</summary>
    public readonly Vector3 Cross(Vector3 v) =>
        new(Y * v.Z - Z * v.Y,
            Z * v.X - X * v.Z,
            X * v.Y - Y * v.X);

    public readonly Vector3 Ceil() => new(MathF.Ceiling(X), MathF.Ceiling(Y), MathF.Ceiling(Z));
    public readonly Vector3 Round() => new(MathF.Round(X), MathF.Round(Y), MathF.Round(Z));
    public readonly Vector3 Abs() => new(MathF.Abs(X), MathF.Abs(Y), MathF.Abs(Z));

    public readonly float AspectXY() => Y == 0 ? float.PositiveInfinity : X / Y;
    public readonly float AspectXZ() => Z == 0 ? float.PositiveInfinity : X / Z;
    public readonly float AspectYZ() => Z == 0 ? float.PositiveInfinity : Y / Z;

    public readonly Vector3 Clamp(Vector3 min, Vector3 max) =>
        new(MathF.Max(min.X, MathF.Min(X, max.X)),
            MathF.Max(min.Y, MathF.Min(Y, max.Y)),
            MathF.Max(min.Z, MathF.Min(Z, max.Z)));

    public readonly Vector3 Clamp(float min, float max) =>
        new(MathF.Max(min, MathF.Min(X, max)),
            MathF.Max(min, MathF.Min(Y, max)),
            MathF.Max(min, MathF.Min(Z, max)));

    /// <summary>Angle between vectors in radians (0…π).</summary>
    public readonly float AngleTo(Vector3 to)
    {
        var denom = Length() * to.Length();
        return denom == 0 ? 0f : MathF.Acos(Math.Clamp(Dot(to) / denom, -1f, 1f));
    }

    public readonly Vector3 Reflect(Vector3 normal)
    {
        var factor = 2f * Dot(normal);
        return factor * normal - this;
    }

    public readonly Vector3 Bounce(Vector3 normal) => -Reflect(normal);

    public readonly Vector3 Lerp(Vector3 to, float weight) =>
        new(AdditionalMath.Lerp(X, to.X, weight),
            AdditionalMath.Lerp(Y, to.Y, weight),
            AdditionalMath.Lerp(Z, to.Z, weight));

    public readonly Vector3 LimitLength(float length = 1f)
    {
        var len = Length();
        return len == 0f || len <= length ? this : this * (length / len);
    }

    /// <summary>Spherical linear interpolation.</summary>
    public readonly Vector3 Slerp(Vector3 to, float t)
    {
        var dot = Math.Clamp(Dot(to) / (Length() * to.Length()), -1f, 1f);
        var theta = MathF.Acos(dot) * t;

        var relVec = (to - this * dot).Normalized();
        return (this * MathF.Cos(theta)) + (relVec * MathF.Sin(theta));
    }

    /// <summary>
    /// Slides this vector along the plane defined by <paramref name="normal"/>.
    /// </summary>
    public readonly Vector3 Slide(Vector3 normal) => this - normal * Dot(normal);

    public readonly Vector3 Snapped(Vector3 step) =>
        new(AdditionalMath.Snapped(X, step.X),
            AdditionalMath.Snapped(Y, step.Y),
            AdditionalMath.Snapped(Z, step.Z));

    public readonly Vector3 Snapped(float step) =>
        new(AdditionalMath.Snapped(X, step),
            AdditionalMath.Snapped(Y, step),
            AdditionalMath.Snapped(Z, step));

    /// <summary>
    /// Returns an arbitrary vector orthogonal to this one.
    /// </summary>
    public readonly Vector3 Orthogonal()
    {
        var absX = MathF.Abs(X);
        var absY = MathF.Abs(Y);
        var absZ = MathF.Abs(Z);

        return absX < absY && absX < absZ
            ? new(0f, -Z, Y)
            : absY < absZ
                ? new(-Z, 0f, X)
                : new(-Y, X, 0f);
    }

    public readonly float Average() => (X + Y + Z) / 3f;

    public readonly void Deconstruct(out float x, out float y, out float z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    #endregion

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y}, {Z})";
}