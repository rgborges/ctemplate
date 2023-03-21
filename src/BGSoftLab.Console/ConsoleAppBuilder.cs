using System;
using System.Collections.Generic;

namespace BGSoftLab.Console
{
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

            public CommandApp Build()
            {
                  var commands = new List<Command>(10);

                  foreach (var cf in _commands)
                  {
                        commands.Add(new Command(cf.Key, cf.Value));
                  }

                  return new CommandApp(commands);
            }
            
      }
}

