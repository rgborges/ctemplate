using System;
using System.Collections.Generic;

namespace BGSoftLab.Console
{
      public class ConsoleAppBuilder
      {
            private bool _interactiveMode = false;
            private readonly string _appName = string.Empty;
            private bool _useHelpCommand = false;
            public bool SetInteractiveMode { get => _interactiveMode; set {
                  _interactiveMode = value;
             } 
            } 
            private List<KeyValuePair<Command, Action<CommandContext>>> _commands;

            public ConsoleAppBuilder(string appName)
            {
                  _appName = appName;
                  _commands = new List<KeyValuePair<Command, Action<CommandContext>>>(10);
            }
            /// <summary>
            ///Add a command configuration to the builder. 
            /// </summary>
            /// <param name="spec">The action of CommandSpecificationCOnfiguration class''jjj'</param>
            /// <param name="act">The action configured to taht command</param>
            /// <returns>Self intance of the builder</returns>
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
                  var commands = new List<ICommand>(10);
                  //Implement the to parse the new commmands
                  foreach (var commandConfig in _commands)
                  {
                        commands.Add(new Command(commandConfig.Key.CommandConfiguration, 
                              commandConfig.Value));
                  }
                  return new CommandApp(commands);
            }
            /// <summary>
            /// Enable the help command through the --help in the console environment arguments. 
            /// </summary>
            /// <returns></returns>
            public ConsoleAppBuilder AddHelpCommand()
            {
                  _useHelpCommand = true;
                  return this;
            }
      }
}

