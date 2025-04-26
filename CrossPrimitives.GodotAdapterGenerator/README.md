# CrossPrimitives.GodotAdapterGenerator

This package generates the necessary code to convert between CrossPrimitives types and Godot's built-in types.
It internally uses Unsafe.As<,>, assuming that the structures have an identical memory layout to Godot's built-in types. This ensures high performance with zero allocations and no data copying.

Additionally, this package generates aliases for CrossPrimitives types to avoid name conflicts with Godot's built-in types.
This is useful when you want to use both CrossPrimitives and Godot types in the same file without ambiguity.

```csharp
global using CpVector2 = CrossPrimitives.Vector2;
global using CpVector2i = CrossPrimitives.Vector2i;
global using CpVector3 = CrossPrimitives.Vector3;
global using CpVector3i = CrossPrimitives.Vector3i;
global using CpVector4 = CrossPrimitives.Vector4;
global using CpVector4i = CrossPrimitives.Vector4i;
global using CpColor = CrossPrimitives.Color;
...
```