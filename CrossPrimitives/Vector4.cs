using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;

/// <summary>
/// Four‑component floating‑point vector (X Y Z W).
/// API is intentionally consistent with <see cref="Vector3"/>.
/// </summary>
public readonly struct Vector4(float x, float y, float z, float w)
{
    #region Static predefined vectors

    private static readonly Vector4 _zero = new(0f, 0f, 0f, 0f);
    private static readonly Vector4 _one = new(1f, 1f, 1f, 1f);
    private static readonly Vector4 _minusOne = new(-1f, -1f, -1f, -1f);
    private static readonly Vector4 _inf = new(float.PositiveInfinity, float.PositiveInfinity,
                                                    float.PositiveInfinity, float.PositiveInfinity);

    // Unit axes
    private static readonly Vector4 _axisX = new(1f, 0f, 0f, 0f);
    private static readonly Vector4 _axisY = new(0f, 1f, 0f, 0f);
    private static readonly Vector4 _axisZ = new(0f, 0f, 1f, 0f);
    private static readonly Vector4 _axisW = new(0f, 0f, 0f, 1f);

    public static Vector4 Zero => _zero;
    public static Vector4 One => _one;
    public static Vector4 MinusOne => _minusOne;
    public static Vector4 Inf => _inf;

    public static Vector4 AxisX => _axisX;
    public static Vector4 AxisY => _axisY;
    public static Vector4 AxisZ => _axisZ;
    public static Vector4 AxisW => _axisW;

    #endregion

    #region Fields & indexer

    public readonly float X = x;
    public readonly float Y = y;
    public readonly float Z = z;
    public readonly float W = w;

    /// <summary>Component indexer (0 ⇒ X, 1 ⇒ Y, 2 ⇒ Z, 3 ⇒ W).</summary>
    public float this[int index] => index switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        3 => W,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for {nameof(Vector4)}.")
    };

    #endregion

    #region Component‑wise modifiers

    public Vector4 WithX(float x) => new(x, Y, Z, W);
    public Vector4 WithY(float y) => new(X, y, Z, W);
    public Vector4 WithZ(float z) => new(X, Y, z, W);
    public Vector4 WithW(float w) => new(X, Y, Z, w);

    #endregion

    #region Arithmetic operators (component‑wise)

    public static Vector4 operator +(Vector4 a, Vector4 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static Vector4 operator -(Vector4 a, Vector4 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);

    public static Vector4 operator *(Vector4 a, Vector4 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
    public static Vector4 operator /(Vector4 a, Vector4 b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);

    public static Vector4 operator *(Vector4 v, float s) => new(v.X * s, v.Y * s, v.Z * s, v.W * s);
    public static Vector4 operator /(Vector4 v, float s) => new(v.X / s, v.Y / s, v.Z / s, v.W / s);
    public static Vector4 operator *(float s, Vector4 v) => new(s * v.X, s * v.Y, s * v.Z, s * v.W);
    public static Vector4 operator /(float s, Vector4 v) => new(s / v.X, s / v.Y, s / v.Z, s / v.W);

    #endregion

    #region Unary operators

    public static Vector4 operator +(Vector4 v) => v;
    public static Vector4 operator -(Vector4 v) => new(-v.X, -v.Y, -v.Z, -v.W);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector4 a, Vector4 b) =>
        a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
    public static bool operator !=(Vector4 a, Vector4 b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector4 v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    #endregion

    #region Utility methods

    /// <summary>Returns the Euclidean length of the vector.</summary>
    public readonly float Length() => MathF.Sqrt(X * X + Y * Y + Z * Z + W * W);

    public readonly float LengthSquared() => X * X + Y * Y + Z * Z + W * W;

    /// <summary>Returns a normalized copy of the vector (unit length).</summary>
    public readonly Vector4 Normalized()
    {
        var len = Length();
        return len == 0f ? this : this / len;
    }

    public readonly float Dot(Vector4 v) => X * v.X + Y * v.Y + Z * v.Z + W * v.W;

    public readonly Vector4 Ceil() => new(MathF.Ceiling(X), MathF.Ceiling(Y), MathF.Ceiling(Z), MathF.Ceiling(W));
    public readonly Vector4 Round() => new(MathF.Round(X), MathF.Round(Y), MathF.Round(Z), MathF.Round(W));
    public readonly Vector4 Abs() => new(MathF.Abs(X), MathF.Abs(Y), MathF.Abs(Z), MathF.Abs(W));

    public readonly Vector4 Clamp(Vector4 min, Vector4 max) =>
        new(MathF.Max(min.X, MathF.Min(X, max.X)),
            MathF.Max(min.Y, MathF.Min(Y, max.Y)),
            MathF.Max(min.Z, MathF.Min(Z, max.Z)),
            MathF.Max(min.W, MathF.Min(W, max.W)));

    public readonly Vector4 Clamp(float min, float max) =>
        new(MathF.Max(min, MathF.Min(X, max)),
            MathF.Max(min, MathF.Min(Y, max)),
            MathF.Max(min, MathF.Min(Z, max)),
            MathF.Max(min, MathF.Min(W, max)));

    /// <summary>Angle between vectors in radians (0…π).</summary>
    public readonly float AngleTo(Vector4 to)
    {
        var denom = Length() * to.Length();
        return denom == 0f ? 0f : MathF.Acos(Math.Clamp(Dot(to) / denom, -1f, 1f));
    }

    public readonly Vector4 Reflect(Vector4 normal)
    {
        var factor = 2f * Dot(normal);
        return factor * normal - this;
    }

    public readonly Vector4 Bounce(Vector4 normal) => -Reflect(normal);

    public readonly Vector4 Lerp(Vector4 to, float weight) =>
        new(AdditionalMath.Lerp(X, to.X, weight),
            AdditionalMath.Lerp(Y, to.Y, weight),
            AdditionalMath.Lerp(Z, to.Z, weight),
            AdditionalMath.Lerp(W, to.W, weight));

    public readonly Vector4 LimitLength(float length = 1f)
    {
        var len = Length();
        return len == 0f || len <= length ? this : this * (length / len);
    }

    /// <summary>Spherical linear interpolation in 4‑D.</summary>
    public readonly Vector4 Slerp(Vector4 to, float t)
    {
        var dot = Math.Clamp(Dot(to) / (Length() * to.Length()), -1f, 1f);
        if (dot > 0.9995f)
        {
            return Lerp(to, t).Normalized() * Length(); // near‑parallel fallback
        }

        var theta = MathF.Acos(dot);
        var sinTheta = MathF.Sin(theta);
        var s0 = MathF.Sin((1f - t) * theta) / sinTheta;
        var s1 = MathF.Sin(t * theta) / sinTheta;
        return (this * s0) + (to * s1);
    }

    /// <summary>Slides this vector along the hyper‑plane defined by <paramref name="normal"/>.</summary>
    public readonly Vector4 Slide(Vector4 normal) => this - normal * Dot(normal);

    public readonly Vector4 Snapped(Vector4 step) =>
        new(AdditionalMath.Snapped(X, step.X),
            AdditionalMath.Snapped(Y, step.Y),
            AdditionalMath.Snapped(Z, step.Z),
            AdditionalMath.Snapped(W, step.W));

    public readonly Vector4 Snapped(float step) =>
        new(AdditionalMath.Snapped(X, step),
            AdditionalMath.Snapped(Y, step),
            AdditionalMath.Snapped(Z, step),
            AdditionalMath.Snapped(W, step));

    /// <summary>
    /// Returns a vector orthogonal to this one (not unique in 4‑D, simple deterministic construction).
    /// </summary>
    public readonly Vector4 Orthogonal()
    {
        // Deterministic perpendicular: (-Y, X, -W, Z)  — dot‑product == 0
        return new(-Y, X, -W, Z);
    }

    public readonly float Average() => (X + Y + Z + W) / 4f;

    public readonly bool IsNormalized()
    {
        return MathF.Abs(LengthSquared() - 1f) < 1E-06f;
    }

    public readonly void Deconstruct(out float x, out float y, out float z, out float w)
    {
        x = X;
        y = Y;
        z = Z;
        w = W;
    }

    #endregion

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y}, {Z}, {W})";
}