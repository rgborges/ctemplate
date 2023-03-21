using System;

namespace BGSoftLab.Console
{
      public interface ICommandSpecBuilder<TBuilder>
      {
            TBuilder SetAction(Action<CommandContext> action);
      }
}