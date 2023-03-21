# Introduction

There is a lot of command line parsing out there. But I decide to create mine just to be more confortable with.

enjoy!

## Specification

Configuring a builder:
```csharp
var builder = new CommandAppBuilder();

builder.AddCommand(config => {
      config.Description = "hello world command";
      config.Key = "hello";
      config.HasInputParameter = true;
      config.InputIndexReference = CommadInputReference.Next;
}, (commandContext) => {
      System.Console.WriteLine("Hello world");
});

```

Adding a command example


```csharp

```
