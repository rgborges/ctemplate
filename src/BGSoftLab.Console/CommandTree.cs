namespace BGSoftLab.Console;
public class CommandTree<T> 
{
      private T? _value;
      private CommandTree<T> _next;
      public T? Value { get => _value; }
      public CommandTree<T> Next { get => _next;}
      public CommandTree(T value, CommandTree<T> Next = null)
      {
            this._value = value;
            this._next = Next;
      }
      public void Add(T s)
      {
            do
            {

            } while(_next is not null);
      }
}