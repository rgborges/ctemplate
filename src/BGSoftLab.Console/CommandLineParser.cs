using System;
using System.Collections.Generic;
using System.Linq;

namespace BGSoftLab.Console;


public class CommandLineParer
{
      /// <summary>
      /// Receives a command line argument and parses it into a command.
      /// </summary>
      /// <param name="args"></param>
      /// <returns></returns>
     public IEnumerable<ICommand> Parse(string[] args, CommandSpecificationConfiguration[] commandSpecifications)
      { 
            var context = new CommandContext(args); 
            foreach (string arg in args)
            {
                  foreach(var c in commandSpecifications.Where(x => x.Key == arg))
                  {

                  }
            } 
      
      throw new NotImplementedException(); 
     } 
}