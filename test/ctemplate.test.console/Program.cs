// See https://aka.ms/new-console-template for more information
using System;
using bgsoftlab.console;


var builder = new ConsoleAppBuilder("dntedemo");

builder.AddCommand(config => {
      config.Key = "help";
      config.Description = "help description command";
      config.HasInputParameter = false;
}, (context) => {
      System.Console.WriteLine("Help command reached");
});

//var app = builder.Build();

Console.ReadLine();