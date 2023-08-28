using System.Collections;
using System.Collections.Generic;

namespace BGSoftLab.Console;


public interface ICommand
{
      /// <summary>
      /// A function to execute the command.
      /// </summary>
      public void Run();
      /// <summary>
      /// A function that valdiates the command based in a command input.
      /// </summary>
      /// <param name="s">The command name you want to validate</param>
      /// <returns>true if it is validates, and false if not  </returns>
      public bool Validate(string s);
      public CommandSpecificationConfiguration GetSpecification();
      public ICollection<CommandOption> GetOptions();
      public ICollection<CommandOption> GetValidatedOptionsWith(string[] args);
}