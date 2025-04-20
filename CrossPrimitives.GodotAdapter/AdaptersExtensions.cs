using System.Runtime.CompilerServices;

namespace CrossPrimitives.GodotAdapter;

public static class AdaptersExtensions
{
    public static Godot.Vector2 AsGodot(this Vector2 vector)
    {
        // Same size as Godot.Vector2, and the layout is the same
        return Unsafe.As<Vector2, Godot.Vector2>(ref vector);
    }

    public static Godot.Vector2I AsGodot(this Vector2i vector)
    {
        // Same size as Godot.Vector2I, and the layout is the same
        return new Godot.Vector2I(vector.X, vector.Y);
    }

    public static Godot.Vector3 AsGodot(this Vector3 vector)
    {
        // Same size as Godot.Vector3, and the layout is the same
        return Unsafe.As<Vector3, Godot.Vector3>(ref vector);
    }

    public static Godot.Vector3I AsGodot(this Vector3i vector)
    {
        // Same size as Godot.Vector3I, and the layout is the same
        return new Godot.Vector3I(vector.X, vector.Y, vector.Z);
    }

    public static Godot.Vector4 AsGodot(this Vector4 vector)
    {
        // Same size as Godot.Vector4, and the layout is the same
        return Unsafe.As<Vector4, Godot.Vector4>(ref vector);
    }

    public static Godot.Vector4I AsGodot(this Vector4i vector)
    {
        // Same size as Godot.Vector4I, and the layout is the same
        return new Godot.Vector4I(vector.X, vector.Y, vector.Z, vector.W);
    }

    public static Godot.Color AsGodot(this Color color)
    {
        // Same size as Godot.Color, and the layout is the same
        return new Godot.Color(color.R, color.G, color.B, color.A);
    }

    public static Vector2 AsCrossPrimitives(this Godot.Vector2 vector)
    {
        // Same size as Vector2, and the layout is the same
        return Unsafe.As<Godot.Vector2, Vector2>(ref vector);
    }

    public static Vector2i AsCrossPrimitives(this Godot.Vector2I vector)
    {
        // Same size as Vector2i, and the layout is the same
        return new Vector2i(vector.X, vector.Y);
    }

    public static Vector3 AsCrossPrimitives(this Godot.Vector3 vector)
    {
        // Same size as Vector3, and the layout is the same
        return Unsafe.As<Godot.Vector3, Vector3>(ref vector);
    }

    public static Vector3i AsCrossPrimitives(this Godot.Vector3I vector)
    {
        // Same size as Vector3i, and the layout is the same
        return new Vector3i(vector.X, vector.Y, vector.Z);
    }

    public static Vector4 AsCrossPrimitives(this Godot.Vector4 vector)
    {
        // Same size as Vector4, and the layout is the same
        return Unsafe.As<Godot.Vector4, Vector4>(ref vector);
    }

    public static Vector4i AsCrossPrimitives(this Godot.Vector4I vector)
    {
        // Same size as Vector4i, and the layout is the same
        return new Vector4i(vector.X, vector.Y, vector.Z, vector.W);
    }

    public static Color AsCrossPrimitives(this Godot.Color color)
    {
        // Same size as Color, and the layout is the same
        return new Color(color.R, color.G, color.B, color.A);
    }
}