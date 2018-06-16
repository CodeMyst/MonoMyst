# Getting Started With ECS

## Creating a scene

Start with making a scene:

```cs
public class MainScene : Scene
{

}
```

To switch to this scene, in your `Game` class create a new instance of this scene:

```cs
public class Game1 : MGame
{
    public Game1 () : base ()
    {
    }

    protected override void Initialize ()
    {
        base.Initialize ();

        Scene mainScene = new MainScene ();
        NextScene (mainScene);
    }
}
```

## Creating entities

Entities are just a collection of components attached to a scene.

Entities have no functionality on their own.

```cs
public class MainScene : Scene
{
    protected override void Initialize ()
    {
        Entity player = new Entity ("Player");
    }
}
```

## Components

Components are simply data containers, they implement no logic whatsoever.

```cs
public class HealthComponent : IComponent
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
}
```

To attach components to entities:

```cs
Entity player = new Entity ("Player");

player.AddComponent<HealthComponent> ();
```

## Systems

Since components are only data containers, you have to use Systems which have a list of all entities with compatible components through which you can loop and do logic.

```cs
public class HealthSystem : ComponentSystem
{
    public HealthSystem (EntityPool entities)
        : base (entities, typeof (HealthComponent))
    {
    }

    protected override void Update (float deltaTime)
    {
        foreach (Entity e in Entities)
        {
            HealthComponent health = e.GetComponent<HealthComponent> ();

            // Logic...
        }
    }
}
```

You can also specify multiple component types, entities which have components of all those types will only be added to the `ComponentSystem`'s `Entities` list.

```cs
public SomeSystem (EntityPool entities)
    : base (entities, typeof (OneComponent),
                      typeof (TwoComponent),
                      typeof (ThreeComponent))
{
}
```

Now you have to instatiate the `ComponentSystem`. It doesn't matter if you do it after or before adding entities since the system will be notified of all the changes on any of the entities.

```cs
public class MainScene : Scene
{
    protected override void Initialize ()
    {
        HealthSystem healthSystem = new HealthSystem (Entities);

        Entity player = new Entity ("Player");
        player.AddComponent<HealthComponent> ();
    }
}
```