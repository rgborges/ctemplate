using System;
using System.Collections.Generic;

namespace BGSoftLab.Console
{
      public class CommandOptionBuilder
      {
            public List<CommandOption> _options;

            public CommandOptionBuilder()
            {
                  _options = new List<CommandOption>(10);
            }

            public CommandOptionBuilder AddOption(Action<CommandOption> config)
            {
                  var opt = new CommandOption();
                  config(opt);
                  _options.Add(opt);
                  return this;
            }

            public List<CommandOption> Build()
            {
                  return _options;
            }

            
      }
}