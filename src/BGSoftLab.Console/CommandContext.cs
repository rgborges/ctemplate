using System;
using System.Collections.Generic;

namespace BGSoftLab.Console;

public class CommandContext
{
      private string[] _args;
      private ICommand _command;
      private int _currentIndex = 0;
      private ICollection<CommandOption> _options;

      public string[]? CommandArgs { get => _args; }
      public int CurrentIndex { get => _currentIndex; }
      public int NextParameter { get => _currentIndex + 1; }
      public ICommand Command { get => _command; }
      ///Later  on we can configure IServiceCollection bus
      public CommandContext(string[] args, ICommand command)
      {
            if (args is null) { throw new NullReferenceException(nameof(args)); }
            if (command is null) { throw new NullReferenceException(nameof(command)); }
            this._args = args;
            this._command = command;
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
      public object? GetParameter()
      {

            if (NextParameter >= _args.Length)
            {
                  return null;
            }
            return _args[NextParameter];
      }
      public void SetOptions(ICollection<CommandOption> options)
      {
            _options = options;
      }
      public IEnumerable<CommandOption> GetOptions()
      {
            return _options ?? new List<CommandOption>();
      }
}