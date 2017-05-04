# Build Script

Within your build script, you will need to add the following (normally near the top of the file):

```csharp
#addin Cake.Ember
```

Once that is complete, you can do the following:

```csharp
EmberBuild(new EmberBuildSettings {
    Environment = "qa"
});
```

or:

```csharp
EmberServe(new EmberServeSettings {
    Environment = "qa"
});
```