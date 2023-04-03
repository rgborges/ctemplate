using System;
using System.Collections.Generic;

namespace BGSoftLab.Console
{
      public class ConsoleAppBuilder
      {
            private readonly string _appName = string.Empty;
            
            private List<KeyValuePair<Command, Action<CommandContext>>> _commands;

            public ConsoleAppBuilder(string appName)
            {
                  _appName = appName;
                  _commands = new List<KeyValuePair<Command, Action<CommandContext>>>(10);
            }
            public ConsoleAppBuilder AddCommand(Action<CommandSpecificationConfiguration> spec, Action<CommandContext> act)
            {
                  var config = new CommandSpecificationConfiguration();
                  spec(config);
                  var incomeCommand = new Command(config, act);
                  _commands.Add(new KeyValuePair<Command, Action<CommandContext>>(incomeCommand, act));
                  return this;
            }

            public CommandApp Build()
            {
                  var commands = new List<Command>(10);
                  //Implement the to parse the new commmands
                  foreach (var commandConfig in _commands)
                  {
                        commands.Add(new Command(commandConfig.Key.CommandConfiguration, 
                              commandConfig.Value));                        
                  }
                  return new CommandApp(commands);
            }
            
      }
}

