namespace BGSoftLab.Console.Results;

public sealed class CommandActionResult
{
      private string[]? _erros;
      private bool _success;


      private CommandActionResult()
      {
            _success = true;
      }
      private CommandActionResult(string[] erros)
      {
            _success = false;
            _erros = erros;
      }

      public static class Create
      {
            public static CommandActionResult Ok()
            {
                  return new CommandActionResult();
            }
            public static CommandActionResult Fail(string[] erros)
            {
                  return new CommandActionResult(erros);
            }
      }
}

