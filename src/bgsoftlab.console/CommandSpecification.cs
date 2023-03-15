namespace bgsoftlab.console;

public record CommandSpecification
{
      public string? Key { get; set; }
      public string? Description { get; set; }
      public bool HasInputParameter { get; set; } = false;
      public CommadInputReference InputIndexReference { get; set; } = CommadInputReference.Next;

}

public enum CommadInputReference
{
      Next,
      Self
}