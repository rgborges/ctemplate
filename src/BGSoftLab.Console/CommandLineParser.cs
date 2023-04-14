using System;
using System.Collections.Generic;
using System.Linq;

namespace BGSoftLab.Console;
public class CommandLineParer
{
      /// <summary>
      /// Receives the program environment arguments and parses it into a IEnumerable of commands.jj 
      /// </summary>
      /// <param name="args"></param>
      /// <returns></returns>
      public IEnumerable<ICommand> Parse(string[] args, CommandSpecificationConfiguration[] commandSpecifications)
      {
            foreach (string s in args)
            {
                  foreach( var commandConfig in commandSpecifications.Where(c => c.Key == s))
                  {
                        if(commandConfig.CommandAction is null)
                        {
                              throw new NullReferenceException($"None action configured in Command Specification {nameof(commandConfig)}");
                        }

                        var command = new Command(commandConfig, commandConfig.CommandAction);

                        if(commandConfig.HasOptionsConfigured)
                        {
                             if(commandConfig.HasOptionsInputParameter)
                             {
                               // command.AddOption(commandConfig.)
                             } 
                        }
                  }
            }
            throw new NotImplementedException();
      }
     
}