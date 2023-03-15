namespace bgsoftlab.console
{
      public interface ICommandSpecBuilder<TBuilder>
      {
            TBuilder SetAction(Action<CommandContext> action);
      }
}