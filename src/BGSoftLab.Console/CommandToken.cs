using System.Collections;
using System.Collections.Generic;

namespace BGSoftLab.Console;

public record struct CommandToken
{
      public int _index;
      public CommandTokenType _type;
      public object? _value;
      public int Index { get => _index; }
      public CommandTokenType Type { get=> _type; }
      public object Value { get => _value; } 
      public CommandToken(int index, CommandTokenType type, object value = null)
      {
            _index = index;
            _type = type;
            _value = value;
      } 

}

public enum CommandTokenType 
{
      Command,
      Option,
      Parameter,
      Invalid
}