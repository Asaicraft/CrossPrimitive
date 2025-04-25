using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives.Behaviors;

public interface IStartable
{
    public IStart Start
    {
        get;
    }
}
