using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives.Behaviors;

public interface ITransform2D
{
    public Vector2 GlobalPosition
    {
        get; set;
    }

    public Vector2 Position
    {
        get; set;
    }

    public Vector2 Scale
    {
        get; set;
    }
}
