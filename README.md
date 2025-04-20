﻿![Build](https://github.com/Asaicraft/CrossPrimitives/actions/workflows/dotnet.yml/badge.svg?)
[![NuGet Stats](https://img.shields.io/nuget/v/CrossPrimitives.svg)](https://www.nuget.org/packages/CrossPrimitives?)
[![Discord](https://img.shields.io/badge/chat-discord-purple.svg)](https://discord.gg/RpxD2BeNsZ)

# CrossPrimitives

**CrossPrimitives** is a lightweight, engine-independent C# primitives library that cleanly separates game/app logic from rendering concerns. Designed to be compatible with any game engine, rendering system, or UI framework.

## Overview

CrossPrimitives provides core types like:

- `Vector2`, `Vector3`, `Vector4` — engine-agnostic math vectors
- `Vector2i`, `Vector3i`, `Vector4i` — integer versions of the above
- `Color` — with full support for:
  - RGBA/ARGB/ABGR 32/64-bit packing
  - Named color support and HTML hex parsing

This library is meant to be **owned by your logic layer**. Your rendering engine (Godot, Unity, MonoGame, etc.) is just a **Presenter** — not the source of truth.

## Philosophy

- ✅ **No engine references** — clean C# structs only
- 🔁 **Reusable across projects**, engines, and platforms
- 🧪 **Fully testable logic layer**
- 🧱 Designed for integration, not opinionated frameworks

## Adapter: Godot Engine

To use CrossPrimitives types in [Godot](https://godotengine.org/), install the adapter:
```bash
dotnet add package CrossPrimitives.GodotAdapter
```

The `CrossPrimitives.GodotAdapter` package provides efficient zero-cost interop between CrossPrimitives and Godot's native types:

```csharp
using CrossPrimitives;
using CrossPrimitives.GodotAdapter;

Vector2 pos = new(1f, 2f);
Godot.Vector2 godotVec = pos.AsGodot();

Color myColor = new Color(1f, 0.5f, 0f);
Godot.Color godotColor = myColor.AsGodot();

Godot.Vector3I godotInt = new Godot.Vector3I(3, 4, 5);
Vector3i crossInt = godotInt.AsCrossPrimitives();
```

The adapter uses Unsafe.As<,> internally, assuming that structures have identical memory layout to Godot's built-in types. This ensures performance with zero allocation and no data copy.