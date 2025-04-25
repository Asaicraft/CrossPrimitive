using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives.Behaviors;

public interface ITransformable
{
    public ITransform Transform
    {
        get; 
    }
}
