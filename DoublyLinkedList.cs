using System.Collections;
public class DoublyLinkedList<T> : IEnumerable<T>
{
  #region Fields
  Node<T>? Head { get; set; } = new Node<T>();
  Node<T>? Tail { get; set; } = new Node<T>();
  public int Count { get; private set; }
  #endregion
#region Methods
  public void AddFirst(T data)
  {
    Node<T> newNode = new Node<T> { Data = data };
    if (Head?.Next == null)
    {
      Head!.Next = newNode;
      Tail!.Previous = newNode;
      Count++;
      return;
    }
    newNode.Next = Head.Next;
    Head.Next.Previous = newNode;
    Head.Next = newNode;
    Count++;
  }

  public void AddLast(T data)
  {
    Node<T> newNode = new Node<T> { Data = data };
    if (Tail?.Previous == null)
    {
      Head!.Next = newNode;
      Tail!.Previous = newNode;
      Count++;
      return;
    }
    Tail.Previous!.Next = newNode;
    newNode.Previous = Tail.Previous;
    Tail.Previous = newNode;
    Count++;
  }

  public void RemoveFirst()
  {
    if (Head?.Next == null)
      return;
    if (Count == 1)
    {
      Head.Next = null;
      Tail!.Previous = null;
      Count--;
    }

    Head.Next!.Next!.Previous = null;
    Head.Next = Head.Next?.Next;
    Count--;
  }

  public void RemoveLast()
  {
    if(Count == 0)
      return;
      if(Count == 1)
        {
          Head!.Next = null;
          Tail!.Previous = null;
          Count--;
        }
    Tail!.Previous!.Previous!.Next = null;
    Tail.Previous = Tail.Previous.Previous;
    Count--;
  }

  public void DisplayFromStart()
  {
    Node<T>? current = Head?.Next;
    while (current != null)
    {
      current.DisplayData();
      current = current.Next;
    }
    System.Console.WriteLine("==================");
  }

  public void DisplayFromEnd()
  {
    Node<T>? current = Tail?.Previous;
    while (current != null)
    {
      current.DisplayData();
      current = current.Previous;
    }
    System.Console.WriteLine("==================");
  }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> Current = Head!.Next!;
        while (Current != null)
        {
            yield return Current.Data!;
            Current = Current.Next!;
        }
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
    #endregion
}




public class Node<T>
{
  #region Fields
  public T? Data { get; set; }
  public Node<T>? Next { get; set; }
  public Node<T>? Previous { get; set; }
  #endregion
  public void DisplayData()
  {
    System.Console.WriteLine(Data);
  }
}