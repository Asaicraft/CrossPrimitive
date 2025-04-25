using System;

namespace CrossPrimitives;

public readonly struct Vector2(float x, float y)
{
    private static readonly Vector2 _zero = new(0f, 0f);
    private static readonly Vector2 _one = new(1f, 1f);
    private static readonly Vector2 _minusOne = new(-1f, -1f);
    private static readonly Vector2 _inf = new(float.PositiveInfinity, float.PositiveInfinity);
    private static readonly Vector2 _up = new(0f, -1f);
    private static readonly Vector2 _down = new(0f, 1f);
    private static readonly Vector2 _right = new(1f, 0f);
    private static readonly Vector2 _left = new(-1f, 0f);

    public static Vector2 Zero => _zero;
    public static Vector2 One => _one;
    public static Vector2 MinusOne => _minusOne;
    public static Vector2 Inf => _inf;
    public static Vector2 Up => _up;
    public static Vector2 Down => _down;
    public static Vector2 Right => _right;
    public static Vector2 Left => _left;

    public static Vector2 FromAngle(float angle)
    {
        var tuple = MathF.SinCos(angle);
        var (y, _) = tuple;
        return new Vector2(tuple.Cos, y);
    }

    public readonly float X = x;
    public readonly float Y = y;

    public float this[int index] => index switch
    {
        0 => X,
        1 => Y,
        _ => throw new IndexOutOfRangeException($"Invalid index {index} for Vector2.")
    };

    public Vector2 WithX(float x)
    {
        return new Vector2(x, Y);
    }

    public Vector2 WithY(float y)
    {
        return new Vector2(X, y);
    }

    #region Arithmetic operators (component‑wise)

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);

    public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
    public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.X / b.X, a.Y / b.Y);

    public static Vector2 operator *(Vector2 v, float s) => new(v.X * s, v.Y * s);
    public static Vector2 operator /(Vector2 v, float s) => new(v.X / s, v.Y / s);
    public static Vector2 operator *(float s, Vector2 v) => new(s * v.X, s * v.Y);
    public static Vector2 operator /(float s, Vector2 v) => new(s / v.X, s / v.Y);

    #endregion

    #region Unary operators

    /// <summary>Identity (returns the same vector).</summary>
    public static Vector2 operator +(Vector2 v) => v;

    /// <summary>Component‑wise negation.</summary>
    public static Vector2 operator -(Vector2 v) => new(-v.X, -v.Y);

    #endregion

    #region Equality & hashing

    public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector2 v && this == v;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion

    #region Utility methods

    /// <summary>Returns the Euclidean length of the vector.</summary>
    public readonly float Length() => MathF.Sqrt(X * X + Y * Y);

    public readonly float LengthSquared()
    {
        return X * X + Y * Y;
    }

    /// <summary>Returns a normalized copy of the vector.</summary>
    public readonly Vector2 Normalized()
    {
        var len = Length();
        return len == 0 ? this : this / len;
    }

    public readonly float Cross(Vector2 v) => X * v.Y - Y * v.X;

    public readonly float Dot(Vector2 v) => X * v.X + Y * v.Y;

    public readonly Vector2 Ceil()
    {
        return new Vector2(MathF.Ceiling(X), MathF.Ceiling(Y));
    }

    public readonly float Aspect()
    {
        return X / Y;
    }

    public readonly Vector2 Clamp(Vector2 min, Vector2 max)
    {
        return new(
            MathF.Max(min.X, MathF.Min(X, max.X)),
            MathF.Max(min.Y, MathF.Min(Y, max.Y))
        );
    }

    public readonly Vector2 Clamp(float min, float max)
    {
        return new(
            MathF.Max(min, MathF.Min(X, max)),
            MathF.Max(min, MathF.Min(Y, max))
        );
    }

    public readonly Vector2 Abs() => new(MathF.Abs(X), MathF.Abs(Y));

    public readonly float Angle() => MathF.Atan2(Y, X);

    public readonly float AngleTo(Vector2 to)
    {
        return MathF.Atan2(Cross(to), Dot(to));
    }

    public readonly float AngleToPoint(Vector2 to)
    {
        return MathF.Atan2(to.Y - Y, to.X - X);
    }
    public readonly Vector2 Reflect(Vector2 normal)
    {
        return 2f * Dot(normal) * normal - this;
    }

    public readonly Vector2 Bounce(Vector2 normal)
    {
        return -Reflect(normal);
    }

    public readonly Vector2 Round()
    {
        return new(MathF.Round(X), MathF.Round(Y));
    }

    public readonly Vector2 Rotated(float angle)
    {
        var (num, num2) = MathF.SinCos(angle);
        return new(X * num2 - Y * num, X * num + Y * num2);
    }

    public readonly Vector2 Sign()
    {
        return new(MathF.Sign(X), MathF.Sign(Y));
    }

    public readonly Vector2 Lerp(Vector2 to, float weight)
    {
        return new(AdditionalMath.Lerp(X, to.X, weight), AdditionalMath.Lerp(Y, to.Y, weight));
    }

    public readonly Vector2 LimitLength(float length = 1f)
    {
        var result = this;
        var num = Length();
        if (num > 0f && length < num)
        {
            result /= num;
            result *= length;
        }

        return result;
    }

    public readonly Vector2 Slerp(Vector2 to, float weight)
    {
        var num = LengthSquared();
        var num2 = to.LengthSquared();

        if ((double)num == 0.0 || (double)num2 == 0.0)
        {
            return Lerp(to, weight);
        }

        var num3 = MathF.Sqrt(num);
        var num4 = AdditionalMath.Lerp(num3, MathF.Sqrt(num2), weight);
        var num5 = AngleTo(to);
        
        return Rotated(num5 * weight) * (num4 / num3);
    }

    public readonly Vector2 Slide(Vector2 normal)
    {
        return this - normal * Dot(normal);
    }

    public readonly Vector2 Snapped(Vector2 step)
    {
        return new(AdditionalMath.Snapped(X, step.X), AdditionalMath.Snapped(Y, step.Y));
    }

    public readonly Vector2 Snapped(float step)
    {
        return new Vector2(AdditionalMath.Snapped(X, step), AdditionalMath.Snapped(Y, step));
    }

    public readonly Vector2 Orthogonal()
    {
        return new Vector2(Y, 0f - X);
    }

    public readonly void Deconstruct(out float x, out float y)
    {
        x = X;
        y = Y;
    }

    public readonly float Average()
    {
        return (X + Y) / 2f;
    }

    #endregion

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y})";
}