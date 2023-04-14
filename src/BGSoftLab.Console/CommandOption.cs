using System;

namespace BGSoftLab.Console
{
      public class CommandOption
      {
            public string Key { get; set; } = String.Empty;
            public Action? Act { get; set; }
      }
}