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

            private ICollection<Command> _commands;
            public CommandApp(ICollection<Command> commands)
            {
                  _commands = commands;
            }
            public void Run(string[] args)
            {
                  bool hasAnyParameterParsed = false;
                  
                  var context = new CommandContext(args, _commands);

                  for(int i = 0; i < args.Length; i++)
                  {
                        foreach(Command c in _commands.Where(c => c.Validate(args[i])))
                        {
                              try
                              {
                                    hasAnyParameterParsed = true;
                                    context.Next(); 
                                    c.SetCommandContext(context);
                                    c.Run();
                              } 
                              catch
                              {
                                    throw;
                              }
                        }
                  }  
                  if(!hasAnyParameterParsed)
                  {
                        PrintHelp();      
                  }
            }
            private void PrintHelp()
            {
                  var sb = new StringBuilder();
                  sb.AppendLine("HELP Section for command line app"); 
                  foreach(var c in _commands)
                  {
                  sb.AppendLine(
                              String.Format("{0}\t{1}",
                                    c.CommandConfiguration.Key,
                                    c.CommandConfiguration.Description
                              ));
                  }
            }
            public void SetInteractiveMode()
            {
                  _interactiveModeEnabled = true;
            }
      }
}