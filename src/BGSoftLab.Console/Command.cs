using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
            private List<CommandOption> _options;

            public CommandSpecificationConfiguration CommandConfiguration { get => _specification;  }

            public Command(CommandSpecificationConfiguration spec, Action<CommandContext> act)
            {
                  _specification = spec;
                  _action = act;
                  _options = new List<CommandOption>(10);


                  if(spec.OptionBuilder is not null) 
                  {
                        var opBuilder = spec.OptionBuilder.Build();
                        _options = opBuilder;
                  }
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
            public void AddOption(CommandOption option)
            {
                  _options.Add(option);
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

        public CommandSpecificationConfiguration GetSpecification()
        {
            return this._specification;
        }
        public ICollection<CommandOption> GetOptions()
        {
            return this._options;
        }

        public ICollection<CommandOption> GetValidatedOptionsWith(string[] keys)
        {
            try
            {
                  var result = new List<CommandOption>();
                  foreach(string arg in keys)
                  {
                        var r = _options.Where(x => x.Key == arg).FirstOrDefault();
                        if (r is not null)
                        {
                              result.Add(r);
                        }
                  }
                  return result;
            }
            catch
            {
                  throw;
            }
        }
    }
}
