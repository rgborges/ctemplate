using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGSoftLab.Console
{
      /// <summary>
      /// CommandApp holds on all the information and behaivior for console app execution.
      /// </summary>
      public class CommandApp
      {
            private bool _interactiveModeEnabled = false;
            public bool IteractiveMode { get => _interactiveModeEnabled; }

            private ICollection<ICommand> _commands;
            public CommandApp(ICollection<ICommand> commands)
            {
                  _commands = commands ?? throw new NullReferenceException(nameof(commands));
            }
            public void Run(string[] args)
            {
                  bool hasAnyParameterParsed = false;

                  for (int i = 0; i < args.Length; i++)
                  {
                        foreach (Command c in _commands.Where(c => c.Validate(args[i])))
                        {
                              try
                              {
                                    var context = new CommandContext(args, c);
                                    hasAnyParameterParsed = true;
                                    context.Next();
                                    context.SetOptions(c.GetValidatedOptionsWith(args)); 
                                    c.SetCommandContext(context);
                                    c.Run();
                              }
                              catch
                              {
                                    throw;
                              }
                        }
                  }
                  if (!hasAnyParameterParsed)
                  {
                        PrintHelp();
                  }
            }
            private void PrintHelp()
            {
                  var sb = new StringBuilder();
                  sb.AppendLine("HELP Section for command line app");
                  foreach (var c in _commands)
                  {
                        var s = c.GetSpecification();
                        sb.AppendLine(
                                    String.Format("{0}\t{1}",
                                          s.Key,
                                          s.Description
                                    ));
                  }
            }
            public void SetInteractiveMode()
            {
                  _interactiveModeEnabled = true;
            }
      }
}