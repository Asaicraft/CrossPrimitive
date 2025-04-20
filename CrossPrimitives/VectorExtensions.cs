using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;
public static class VectorExtensions
{
    public static Vector2 AsVector2(this Vector2 v) => new(v.X, v.Y);
    public static Vector2 AsVector2(this Vector2i v) => new(v.X, v.Y);
    public static Vector2 AsVector2(this Vector3 v) => new(v.X, v.Y);
    public static Vector2 AsVector2(this Vector3i v) => new(v.X, v.Y);
    public static Vector2 AsVector2(this Vector4 v) => new(v.X, v.Y);
    public static Vector2 AsVector2(this Vector4i v) => new(v.X, v.Y);

    public static Vector2i AsVector2i(this Vector2 v) => new((int)v.X, (int)v.Y);
    public static Vector2i AsVector2i(this Vector2i v) => new(v.X, v.Y);
    public static Vector2i AsVector2i(this Vector3 v) => new((int)v.X, (int)v.Y);
    public static Vector2i AsVector2i(this Vector3i v) => new(v.X, v.Y);
    public static Vector2i AsVector2i(this Vector4 v) => new((int)v.X, (int)v.Y);
    public static Vector2i AsVector2i(this Vector4i v) => new(v.X, v.Y);

    public static Vector3 AsVector3(this Vector2 v) => new(v.X, v.Y, 0f);
    public static Vector3 AsVector3(this Vector2i v) => new(v.X, v.Y, 0f);
    public static Vector3 AsVector3(this Vector3 v) => new(v.X, v.Y, v.Z);
    public static Vector3 AsVector3(this Vector3i v) => new(v.X, v.Y, v.Z);
    public static Vector3 AsVector3(this Vector4 v) => new(v.X, v.Y, v.Z);
    public static Vector3 AsVector3(this Vector4i v) => new(v.X, v.Y, v.Z);

    public static Vector3i AsVector3i(this Vector2 v) => new((int)v.X, (int)v.Y, 0);
    public static Vector3i AsVector3i(this Vector2i v) => new(v.X, v.Y, 0);
    public static Vector3i AsVector3i(this Vector3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static Vector3i AsVector3i(this Vector3i v) => new(v.X, v.Y, v.Z);
    public static Vector3i AsVector3i(this Vector4 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static Vector3i AsVector3i(this Vector4i v) => new(v.X, v.Y, v.Z);

    public static Vector4 AsVector4(this Vector2 v) => new(v.X, v.Y, 0f, 0f);
    public static Vector4 AsVector4(this Vector2i v) => new(v.X, v.Y, 0f, 0f);
    public static Vector4 AsVector4(this Vector3 v) => new(v.X, v.Y, v.Z, 0f);
    public static Vector4 AsVector4(this Vector3i v) => new(v.X, v.Y, v.Z, 0f);
    public static Vector4 AsVector4(this Vector4 v) => v; // identity
    public static Vector4 AsVector4(this Vector4i v) => new(v.X, v.Y, v.Z, v.W);

    public static Vector4i AsVector4i(this Vector2 v) => new((int)v.X, (int)v.Y, 0, 0);
    public static Vector4i AsVector4i(this Vector2i v) => new(v.X, v.Y, 0, 0);
    public static Vector4i AsVector4i(this Vector3 v) => new((int)v.X, (int)v.Y, (int)v.Z, 0);
    public static Vector4i AsVector4i(this Vector3i v) => new(v.X, v.Y, v.Z, 0);
    public static Vector4i AsVector4i(this Vector4 v) => new((int)v.X, (int)v.Y, (int)v.Z, (int)v.W);
    public static Vector4i AsVector4i(this Vector4i v) => v; // identity
}