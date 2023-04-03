using System;

namespace BGSoftLab.Console;

public class CommandSpecificationConfiguration
{
      public string? Key { get; set; }
      public string? Description { get; set; }
      public bool HasInputParameter { get; set; } = false;
      public CommadInputReference InputIndexReference { get; set; } = CommadInputReference.Next;
      public Action<CommandContext>? CommandAction { get; set; }
}

public enum CommadInputReference
{
      Next,
      Self
}
