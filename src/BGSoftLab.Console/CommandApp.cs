using System.Collections.Generic;
using System.Linq;

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
                  var context = new CommandContext();

                  context.CommandArgs = args;
                  
                  for(int i = 0; i < args.Length; i++)
                  {
                        foreach(Command c in _commands.Where(c => c.Validate(args[i])))
                        {
                              try
                              {
                                    context.CurrentIndex = i;
                                    context.NextParameter = i + 1;
                                    
                                    c.SetCommandContext(context);
                                    
                                    c.Run();
                              }
                              catch
                              {
                                    throw;
                              }
                        }
                  }  
            }
      }
}

