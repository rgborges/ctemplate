using System;
using BGSoftLab.Console;


var builder = new ConsoleAppBuilder("app");


builder.AddCommand(config => {
      config.Description = "hello world command";
      config.Key = "hello";
      config.HasInputParameter = true;
      config.InputIndexReference = CommadInputReference.Next;
}, (commandContext) => {
      var parameter = commandContext.GetParameter();
      if (parameter is null) {
            System.Console.WriteLine("Hello");
            return;
      }
      System.Console.WriteLine("Hello {0}", parameter);
});
var app = builder.Build();
app.Run(Environment.GetCommandLineArgs());
