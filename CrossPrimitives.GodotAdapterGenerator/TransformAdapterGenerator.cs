using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPrimitives.GodotAdapterGenerator;

[Generator(LanguageNames.CSharp)]
public sealed class TransformAdapterGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            var code = GenerateCode();
            ctx.AddSource(
                "TransformAdapter.g.cs",
                SourceText.From(code, Encoding.UTF8)
            );
        });
    }

    private static string GenerateCode()
    {
        return """
using CrossPrimitives.Behaviors;
using Godot;

namespace CrossPrimitives.GodotAdapter
{
    public sealed class TransformAdapter : ITransform2D, ITransformable2D
    {

        public TransformAdapter(Node2D node2D)
        {
            Node2D = node2D;
        }

        public Node2D Node2D
        {
            get;
        }

        public CpVector2 Position
        {
            get => Node2D.Position.AsCrossPrimitives();
            set => Node2D.Position = value.AsGodot();
        }

        public CpVector2 GlobalPosition
        {
            get => Node2D.GlobalPosition.AsCrossPrimitives();
            set => Node2D.GlobalPosition = value.AsGodot();
        }

        public CpVector2 Scale
        {
            get => Node2D.Scale.AsCrossPrimitives();
            set => Node2D.Scale = value.AsGodot();
        }

        public ITransform2D Transform => this;
    }
}
""";
    }
}
