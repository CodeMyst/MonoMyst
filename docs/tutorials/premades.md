# Premades

Premades are a way to create entities with predefined components and properties. This is basically Unity's Prefab system.

## Defining a premade

Create a yaml file (preferred extension for premades is .mpm, but can be whatever).

Example premade:
```yml
---
Name: Entity name

Components:
  - Type: TransformComponent
    Position:
      X: 150
      Y: 100
    Size:
      X: 10
      Y: 5

  - Type: SpriteComponent
    Color: White
    Sprite: MonoMyst/Rectangle
...
```

Currently premades only support these types (list will change in future):
* Vector2
* Color
* Enum
* Primitives (numbers, strings, etc.)
* Texture2D (placed in the Contents directory)
* Dictionary of <string, Texture2D>

## Creating a premade

To create an Entity from a Premade:
```cs
Entity e = Premade.Create("Contents/Premades/Test.mpm");
```