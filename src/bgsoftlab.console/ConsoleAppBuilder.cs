namespace bgsoftlab.console;

public class ConsoleAppBuilder
{
      private readonly string _appName = string.Empty;
      
      private List<KeyValuePair<CommandSpecification, Action<CommandContext>>> _commands;

      public ConsoleAppBuilder(string appName)
      {
            _appName = appName;
            _commands = new List<KeyValuePair<CommandSpecification, Action<CommandContext>>>(10);
      }
      public ConsoleAppBuilder AddCommand(Action<CommandSpecification> spec, Action<CommandContext> act)
      {
            var inSpec = new CommandSpecification();
            
            spec(inSpec);

            _commands.Add(new KeyValuePair<CommandSpecification, Action<CommandContext>>(inSpec, act));

            return this;
      }
      
}
