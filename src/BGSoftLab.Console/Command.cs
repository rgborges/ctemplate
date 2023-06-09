using System;

namespace BGSoftLab.Console
{
      /// <summary>
      /// Represents a Command parsed from the parser; 
      /// </summary>
      public class Command : ICommand
      {
            private CommandContext? _context;
            private readonly CommandSpecificationConfiguration _specification;
            private readonly Action<CommandContext> _action;

            public CommandSpecificationConfiguration CommandConfiguration { get => _specification;  }

            public Command(CommandSpecificationConfiguration spec, Action<CommandContext> act)
            {
                  _specification = spec;
                  _action = act;
            }
            public Command(CommandContext context, CommandSpecificationConfiguration spec, Action<CommandContext> act)
            {
                  _context = context;
                  _specification = spec;
                  _action = act;
            }
           public bool Validate(string input)
           { 
                  if(input == _specification.Key)
                  {
                        return true;
                  }
                  return false;
            }
            public void SetCommandContext(CommandContext context)
            {
                  _context = context;
            }
            public void Run()
            {
                  if(_context is null || _specification is null)
                  {
                        throw new NullReferenceException(
                              String.Format("either {0} or {1} is null.",
                              nameof(_context), nameof(_specification))
                              );
                  }
                  
                  try
                  {
                        _action(_context);
                  }
                  catch
                  {
                    throw;
                  }
            }
      }
}
