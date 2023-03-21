namespace BGSoftLab.Console;

public class CommandContext
{
      public string[]? CommandArgs { get; set; }
      public int CurrentIndex { get; set; }
      public int NextParameter { get; set; }
      
      ///Later  on we can configure IServiceCollection bus

}