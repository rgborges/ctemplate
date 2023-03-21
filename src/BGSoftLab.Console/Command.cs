using System;

namespace BGSoftLab.Console
{
      public class Command : ICommand
      {
            private CommandContext? _context;
            private readonly CommandSpecification _specification;
            private readonly Action<CommandContext> _action;

            public Command(CommandSpecification spec, Action<CommandContext> act)
            {
                  _specification = spec;
                  _action = act;
            }
            public Command(CommandContext context, CommandSpecification spec, Action<CommandContext> act)
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
