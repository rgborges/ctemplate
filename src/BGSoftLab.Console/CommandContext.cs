using System;
using System.Collections.Generic;

namespace BGSoftLab.Console;

public class CommandContext
{
      private string[] _args;
      private ICollection<Command> _commandsConfig;
      private int _currentIndex = 0;
      private string[] args;

      public string[]? CommandArgs { get => _args; }
      public int CurrentIndex { get => _currentIndex; }
      public int NextParameter { get => _currentIndex + 1; }

      public IEnumerable<Command> CommandsConfiguration { get => _commandsConfig;}
      
      ///Later  on we can configure IServiceCollection bus

      public CommandContext(string[] args, ICollection<Command> commands) 
      {
           _args = args;
           _commandsConfig = commands;
      }

      public CommandContext(string[] args)
      {
            this.args = args;
      }

      public void Next()
      {
            _currentIndex++;
      }
      public string GetCurrentIndexValue()
      {
            return _args[_currentIndex];
      }
/// <summary>
/// Retrieves the parameter for the command if applicable. 
/// </summary>
/// <returns>The parameter argument as an object</returns>
      public object GetParameter()
      {
            
            if(NextParameter >= _args.Length)
            {
                  return null;
            }
            return _args[NextParameter];
      }
}