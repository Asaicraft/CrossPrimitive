using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;

public static class AdditionalMath
{
    public static float Lerp(float from, float to, float weight)
    {
        return from + (to - from) * weight;
    }

    public static double Lerp(double from, double to, double weight)
    {
        return from + (to - from) * weight;
    }

    public static float Snapped(float s, float step)
    {
        if (step != 0f)
        {
            return MathF.Floor(s / step + 0.5f) * step;
        }

        return s;
    }

    public static double Snapped(double s, double step)
    {
        if (step != 0.0)
        {
            return Math.Floor(s / step + 0.5) * step;
        }
        return s;
    }

    public static bool IsEqualApprox(float a, float b)
    {
        if (a == b)
        {
            return true;
        }

        var num = 1E-06f * Math.Abs(a);
        if (num < 1E-06f)
        {
            num = 1E-06f;
        }

        return Math.Abs(a - b) < num;
    }

    public static bool IsEqualApprox(double a, double b)
    {
        if (a == b)
        {
            return true;
        }
        var num = 1E-06 * Math.Abs(a);
        if (num < 1E-06)
        {
            num = 1E-06;
        }
        return Math.Abs(a - b) < num;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RoundToInt(float s)
    {
        return (int)MathF.Round(s);
    }
}
