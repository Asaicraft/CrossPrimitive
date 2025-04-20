using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;
using System;

/// <summary>
/// Two‑component vector of 32‑bit signed integers.
/// Mirrors the API surface of <see cref="Vector2"/>.
/// </summary>
public readonly struct Vector2i(int x, int y)
{
    #region Static predefined vectors

    private static readonly Vector2i _zero = new(0, 0);
    private static readonly Vector2i _one = new(1, 1);
    private static readonly Vector2i _minusOne = new(-1, -1);
    private static readonly Vector2i _up = new(0, -1);
    private static readonly Vector2i _down = new(0, 1);
    private static readonly Vector2i _right = new(1, 0);
    private static readonly Vector2i _left = new(-1, 0);
    private static readonly Vector2i _max = new(int.MaxValue, int.MaxValue);
    private static readonly Vector2i _min = new(int.MinValue, int.MinValue);

    public static Vector2i Zero => _zero;
    public static Vector2i One => _one;
    public static Vector2i MinusOne => _minusOne;
    public static Vector2i Up => _up;
    public static Vector2i Down => _down;
    public static Vector2i Right => _right;
    public static Vector2i Left => _left;
    public static Vector2i Max => _max;
    public static Vector2i Min => _min;

    /// <summary>
    /// Builds an integer direction vector from the given <paramref name="angle"/> (radians).
    /// </summary>
    public static Vector2i FromAngle(float angle)
    {
        var tuple = MathF.SinCos(angle);
        var (sin, cos) = tuple;                     // (y, x)
        return new((int)MathF.Round(cos), (int)MathF.Round(sin));
    }

    #endregion

    #region Fields & indexer

    public readonly int X = x;
    public readonly int Y = y;

    /// <summary>Component indexer (0 => X, 1 => Y).</summary>
    public int this[int index] => index switch
    {
        0 => X,
        1 => Y,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for {nameof(Vector2i)}.")
    };

    #endregion

    #region Component‑wise modifiers

    public Vector2i WithX(int x) => new(x, Y);
    public Vector2i WithY(int y) => new(X, y);

    #endregion

    #region Arithmetic operators

    public static Vector2i operator +(Vector2i a, Vector2i b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2i operator -(Vector2i a, Vector2i b) => new(a.X - b.X, a.Y - b.Y);

    public static Vector2i operator *(Vector2i a, Vector2i b) => new(a.X * b.X, a.Y * b.Y);
    public static Vector2i operator /(Vector2i a, Vector2i b) => new(a.X / b.X, a.Y / b.Y);

    public static Vector2i operator *(Vector2i v, int s) => new(v.X * s, v.Y * s);
    public static Vector2i operator /(Vector2i v, int s) => new(v.X / s, v.Y / s);

    public static Vector2i operator *(Vector2i v, float s) => new((int)MathF.Round(v.X * s), (int)MathF.Round(v.Y * s));
    public static Vector2i operator /(Vector2i v, float s) => new((int)MathF.Round(v.X / s), (int)MathF.Round(v.Y / s));

    public static Vector2i operator *(int s, Vector2i v) => new(s * v.X, s * v.Y);
    public static Vector2i operator /(int s, Vector2i v) => new(s / v.X, s / v.Y);

    public static Vector2i operator *(float s, Vector2i v) => new((int)MathF.Round(s * v.X), (int)MathF.Round(s * v.Y));
    public static Vector2i operator /(float s, Vector2i v) => new((int)MathF.Round(s / v.X), (int)MathF.Round(s / v.Y));

    #endregion

    #region Unary operators

    public static Vector2i operator +(Vector2i v) => v;
    public static Vector2i operator -(Vector2i v) => new(-v.X, -v.Y);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector2i a, Vector2i b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Vector2i a, Vector2i b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector2i v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion

    #region Utility methods

    /// <summary>Euclidean length (float).</summary>
    public readonly float Length() => MathF.Sqrt((X * X) + (Y * Y));

    public readonly int LengthSquared() => X * X + Y * Y;

    /// <summary>
    /// Returns a normalized <see cref="Vector2"/> (not integer) copy.
    /// </summary>
    public readonly Vector2 Normalized()
    {
        var len = Length();
        return len == 0 ? new Vector2(0f, 0f) : new Vector2(X / len, Y / len);
    }

    public readonly int Cross(Vector2i v) => X * v.Y - Y * v.X;
    public readonly int Dot(Vector2i v) => X * v.X + Y * v.Y;

    public readonly Vector2i Abs() => new(Math.Abs(X), Math.Abs(Y));

    public readonly float Aspect() => Y == 0 ? float.PositiveInfinity : (float)X / Y;

    public readonly Vector2i Clamp(Vector2i min, Vector2i max)
        => new(Math.Clamp(X, min.X, max.X), Math.Clamp(Y, min.Y, max.Y));

    public readonly Vector2i Clamp(int min, int max)
        => new(Math.Clamp(X, min, max), Math.Clamp(Y, min, max));

    public readonly float Angle() => MathF.Atan2(Y, X);

    public readonly float AngleTo(Vector2i to)
        => MathF.Atan2(Cross(to), Dot(to));

    public readonly float AngleToPoint(Vector2i to)
        => MathF.Atan2(to.Y - Y, to.X - X);

    public readonly Vector2i Reflect(Vector2i normal)
    {
        var dot2 = 2 * Dot(normal);
        return new(dot2 * normal.X - X, dot2 * normal.Y - Y);
    }

    public readonly Vector2i Bounce(Vector2i normal) => -Reflect(normal);

    public readonly Vector2i Rotated(float angle)
    {
        var (sin, cos) = MathF.SinCos(angle);
        var nx = (int)MathF.Round((X * cos) - (Y * sin));
        var ny = (int)MathF.Round((X * sin) + (Y * cos));
        return new(nx, ny);
    }

    public readonly Vector2i Sign() => new(Math.Sign(X), Math.Sign(Y));

    public readonly Vector2i Lerp(Vector2i to, float weight)
    {
        var nx = AdditionalMath.Lerp(X, to.X, weight);
        var ny = AdditionalMath.Lerp(Y, to.Y, weight);
        return new((int)MathF.Round(nx), (int)MathF.Round(ny));
    }

    public readonly Vector2i LimitLength(int length = 1)
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
            (int)MathF.Round(Y * scale)
        );
    }

    public readonly Vector2i Slerp(Vector2i to, float weight)
    {
        var lenA = Length();
        var lenB = to.Length();
        if (lenA == 0 || lenB == 0)
        {
            return Lerp(to, weight);
        }

        var angle = AngleTo(to);
        var len = AdditionalMath.Lerp(lenA, lenB, weight);
        var rotated = Rotated(angle * weight);
        var scale = len / lenA;
        return (rotated * scale);
    }

    public readonly Vector2i Slide(Vector2i normal) => this - (Dot(normal) * normal);

    public readonly Vector2i Snapped(Vector2i step)
        => new((int)AdditionalMath.Snapped(X, step.X), (int)AdditionalMath.Snapped(Y, step.Y));

    public readonly Vector2i Snapped(int step)
        => new((int)AdditionalMath.Snapped(X, step), (int)AdditionalMath.Snapped(Y, step));

    public readonly Vector2i Orthogonal() => new(Y, -X);

    public readonly void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    #endregion

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y})";
}
