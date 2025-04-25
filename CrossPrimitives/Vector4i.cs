using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;
/// <summary>
/// Four‑component vector of 32‑bit signed integers (X Y Z W).
/// Mirrors the API surface of <see cref="Vector4"/>.
/// </summary>
public readonly struct Vector4i(int x, int y, int z, int w)
{
    #region Static predefined vectors

    private static readonly Vector4i _zero = new(0, 0, 0, 0);
    private static readonly Vector4i _one = new(1, 1, 1, 1);
    private static readonly Vector4i _minusOne = new(-1, -1, -1, -1);
    private static readonly Vector4i _max = new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
    private static readonly Vector4i _min = new(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

    // Unit axes
    private static readonly Vector4i _axisX = new(1, 0, 0, 0);
    private static readonly Vector4i _axisY = new(0, 1, 0, 0);
    private static readonly Vector4i _axisZ = new(0, 0, 1, 0);
    private static readonly Vector4i _axisW = new(0, 0, 0, 1);

    public static Vector4i Zero => _zero;
    public static Vector4i One => _one;
    public static Vector4i MinusOne => _minusOne;
    public static Vector4i Max => _max;
    public static Vector4i Min => _min;

    public static Vector4i AxisX => _axisX;
    public static Vector4i AxisY => _axisY;
    public static Vector4i AxisZ => _axisZ;
    public static Vector4i AxisW => _axisW;

    #endregion

    #region Fields & indexer

    public readonly int X = x;
    public readonly int Y = y;
    public readonly int Z = z;
    public readonly int W = w;

    /// <summary>Component indexer (0 ⇒ X, 1 ⇒ Y, 2 ⇒ Z, 3 ⇒ W).</summary>
    public int this[int index] => index switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        3 => W,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for {nameof(Vector4i)}.")
    };

    #endregion

    #region Component‑wise modifiers

    public Vector4i WithX(int x) => new(x, Y, Z, W);
    public Vector4i WithY(int y) => new(X, y, Z, W);
    public Vector4i WithZ(int z) => new(X, Y, z, W);
    public Vector4i WithW(int w) => new(X, Y, Z, w);

    #endregion

    #region Arithmetic operators

    public static Vector4i operator +(Vector4i a, Vector4i b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static Vector4i operator -(Vector4i a, Vector4i b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);

    public static Vector4i operator *(Vector4i a, Vector4i b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
    public static Vector4i operator /(Vector4i a, Vector4i b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);

    public static Vector4i operator *(Vector4i v, int s) => new(v.X * s, v.Y * s, v.Z * s, v.W * s);
    public static Vector4i operator /(Vector4i v, int s) => new(v.X / s, v.Y / s, v.Z / s, v.W / s);

    public static Vector4i operator *(Vector4i v, float s) =>
        new((int)MathF.Round(v.X * s), (int)MathF.Round(v.Y * s), (int)MathF.Round(v.Z * s), (int)MathF.Round(v.W * s));
    public static Vector4i operator /(Vector4i v, float s) =>
        new((int)MathF.Round(v.X / s), (int)MathF.Round(v.Y / s), (int)MathF.Round(v.Z / s), (int)MathF.Round(v.W / s));

    public static Vector4i operator *(int s, Vector4i v) => new(s * v.X, s * v.Y, s * v.Z, s * v.W);
    public static Vector4i operator /(int s, Vector4i v) => new(s / v.X, s / v.Y, s / v.Z, s / v.W);

    public static Vector4i operator *(float s, Vector4i v) =>
        new((int)MathF.Round(s * v.X), (int)MathF.Round(s * v.Y), (int)MathF.Round(s * v.Z), (int)MathF.Round(s * v.W));
    public static Vector4i operator /(float s, Vector4i v) =>
        new((int)MathF.Round(s / v.X), (int)MathF.Round(s / v.Y), (int)MathF.Round(s / v.Z), (int)MathF.Round(s / v.W));

    #endregion

    #region Unary operators

    public static Vector4i operator +(Vector4i v) => v;
    public static Vector4i operator -(Vector4i v) => new(-v.X, -v.Y, -v.Z, -v.W);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector4i a, Vector4i b) =>
        a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
    public static bool operator !=(Vector4i a, Vector4i b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector4i v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    #endregion

    #region Utility methods

    /// <summary>Euclidean length (float).</summary>
    public readonly float Length() => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));

    public readonly int LengthSquared() => X * X + Y * Y + Z * Z + W * W;

    /// <summary>Returns a normalized <see cref="Vector4"/>.</summary>
    public readonly Vector4 Normalized()
    {
        var len = Length();
        return len == 0f
            ? new Vector4(0f, 0f, 0f, 0f)
            : new Vector4(X / len, Y / len, Z / len, W / len);
    }

    public readonly int Dot(Vector4i v) => X * v.X + Y * v.Y + Z * v.Z + W * v.W;

    public readonly Vector4i Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z), Math.Abs(W));

    public readonly Vector4i Clamp(Vector4i min, Vector4i max) =>
        new(Math.Clamp(X, min.X, max.X),
            Math.Clamp(Y, min.Y, max.Y),
            Math.Clamp(Z, min.Z, max.Z),
            Math.Clamp(W, min.W, max.W));

    public readonly Vector4i Clamp(int min, int max) =>
        new(Math.Clamp(X, min, max),
            Math.Clamp(Y, min, max),
            Math.Clamp(Z, min, max),
            Math.Clamp(W, min, max));

    /// <summary>Angle between vectors in radians (0…π).</summary>
    public readonly float AngleTo(Vector4i to)
    {
        var denom = Length() * to.Length();
        return denom == 0f ? 0f : MathF.Acos(Math.Clamp((float)Dot(to) / denom, -1f, 1f));
    }

    public readonly Vector4i Reflect(Vector4i normal)
    {
        var factor = 2 * Dot(normal);
        return new(factor * normal.X - X,
                   factor * normal.Y - Y,
                   factor * normal.Z - Z,
                   factor * normal.W - W);
    }

    public readonly Vector4i Bounce(Vector4i normal) => -Reflect(normal);

    public readonly Vector4i Lerp(Vector4i to, float weight)
    {
        var nx = AdditionalMath.Lerp(X, to.X, weight);
        var ny = AdditionalMath.Lerp(Y, to.Y, weight);
        var nz = AdditionalMath.Lerp(Z, to.Z, weight);
        var nw = AdditionalMath.Lerp(W, to.W, weight);
        return new((int)MathF.Round(nx), (int)MathF.Round(ny),
                   (int)MathF.Round(nz), (int)MathF.Round(nw));
    }

    public readonly Vector4i LimitLength(int length = 1)
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
            (int)MathF.Round(Z * scale),
            (int)MathF.Round(W * scale));
    }

    /// <summary>Spherical linear interpolation in 4‑D.</summary>
    public readonly Vector4i Slerp(Vector4i to, float t)
    {
        var lenA = Length();
        var lenB = to.Length();
        if (lenA == 0f || lenB == 0f)
        {
            return Lerp(to, t);
        }

        var dot = Math.Clamp((float)Dot(to) / (lenA * lenB), -1f, 1f);
        if (dot > 0.9995f)
        {
            return Lerp(to, t);
        }

        var theta = MathF.Acos(dot);
        var sinTheta = MathF.Sin(theta);
        var s0 = MathF.Sin((1f - t) * theta) / sinTheta;
        var s1 = MathF.Sin(t * theta) / sinTheta;

        var v0 = this * s0;
        var v1 = to * s1;
        return new(
            (int)MathF.Round(v0.X + v1.X),
            (int)MathF.Round(v0.Y + v1.Y),
            (int)MathF.Round(v0.Z + v1.Z),
            (int)MathF.Round(v0.W + v1.W));
    }

    public readonly Vector4i Slide(Vector4i normal) => this - (Dot(normal) * normal);

    public readonly Vector4i Snapped(Vector4i step) =>
        new((int)AdditionalMath.Snapped(X, step.X),
            (int)AdditionalMath.Snapped(Y, step.Y),
            (int)AdditionalMath.Snapped(Z, step.Z),
            (int)AdditionalMath.Snapped(W, step.W));

    public readonly Vector4i Snapped(int step) =>
        new((int)AdditionalMath.Snapped(X, step),
            (int)AdditionalMath.Snapped(Y, step),
            (int)AdditionalMath.Snapped(Z, step),
            (int)AdditionalMath.Snapped(W, step));

    /// <summary>
    /// Deterministic orthogonal integer vector: (-Y, X, -W, Z). Dot‑product == 0.
    /// </summary>
    public readonly Vector4i Orthogonal() => new(-Y, X, -W, Z);

    public readonly float Average() => (X + Y + Z + W) / 4f;

    public readonly void Deconstruct(out int x, out int y, out int z, out int w)
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