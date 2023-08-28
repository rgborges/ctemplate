using System;
using BGSoftLab.Console;


var builder = new ConsoleAppBuilder("app");


builder.AddCommand(config =>
{
    config.Description = "hello world command";
    config.Key = "hello";
    config.HasInputParameter = true;
    config.InputIndexReference = CommadInputReference.Next;
    config.OptionBuilder = new CommandOptionBuilder()
                                        .AddOption(config =>
                                        {
                                            config.Key = "-c";
                                            config.Act = () =>
                                            {
                                                System.Console.ForegroundColor = ConsoleColor.Blue;
                                            };
                                        });
}, (commandContext) =>
{
    var options = commandContext.GetOptions();

    if (options is not null)
    {
        foreach (var opt in options)
        {
           var a = opt.Act;
           if(a is null) { continue; }
           a();
        }
    }
    var parameter = commandContext.GetParameter();
    if (parameter is null)
    {
        System.Console.WriteLine("Hello");
        return;
    }
    System.Console.WriteLine("Hello {0}", parameter);
});

builder.AddHelpCommand();

var app = builder.Build();

app.Run(Environment.GetCommandLineArgs());


